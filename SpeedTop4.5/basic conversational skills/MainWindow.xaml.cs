namespace Firebase.Auth.Social
{
    using Database;
    using Database.Query;
    using Facebook;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Util;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    public partial class MainWindow : Window
    {
        // TODO: fill these out
        public const string FacebookAppId = "<FACEBOOK APP ID>"; // https://developers.facebook.com/
        public const string GoogleClientId = "123435845514-a9kp6a3ufl0k7vl5j6bh59e1rbf6jnm8.apps.googleusercontent.com"; // https://console.developers.google.com/apis/credentials
        public const string FirebaseAppKey = "AIzaSyDJobbjrnR8tWADsskVKBnm8SWfc1LA9fM"; // https://console.firebase.google.com/
        public const string FirebaseAppUri = "https://pocketsprinter-54f15.firebaseio.com/";
        private IReadOnlyCollection<FirebaseObject<object>> dbData;
        private FirebaseAuthLink data;
        private FirebaseAuthProvider auth;
        private FirebaseClient db;
        private string whodis;
        private string naampie;
        Punten puntjes = new Punten();


        public MainWindow()
        {
            InitializeComponent();
        }



    private void FacebookClick(object sender, RoutedEventArgs e)
        {
            var loginUri = this.GenerateFacebookLoginUrl(FacebookAppId, "email");

            this.Browser.Visibility = Visibility.Visible;
            this.Browser.Navigate(loginUri);
        }

        private async void GoogleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var cr = new PromptCodeReceiver();

                var result = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets { ClientId = GoogleClientId },
                    new[] { "email", "profile" },
                    "user",
                    CancellationToken.None);

                if (result.Token.IsExpired(SystemClock.Default))
                {
                    await result.RefreshTokenAsync(CancellationToken.None);
                }

                this.FetchFirebaseData(result.Token.AccessToken, FirebaseAuthType.Google);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Uri GenerateFacebookLoginUrl(string appId, string extendedPermissions)
        {
            // copied from http://stackoverflow.com/questions/29621427/facebook-sdk-integration-in-wpf-application

            dynamic parameters = new ExpandoObject();
            parameters.client_id = appId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";

            // The requested response: an access token (token), an authorization code (code), or both (code token).
            parameters.response_type = "token";

            // list of additional display modes can be found at http://developers.facebook.com/docs/reference/dialogs/#display
            parameters.display = "popup";

            // add the 'scope' parameter only if we have extendedPermissions.
            if (!string.IsNullOrWhiteSpace(extendedPermissions))
                parameters.scope = extendedPermissions;

            // generate the login url
            var fb = new FacebookClient();
            return fb.GetLoginUrl(parameters);
        }

        private void BrowserNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var fb = new FacebookClient();
            FacebookOAuthResult oauthResult;
            if (!fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }

            if (oauthResult.IsSuccess)
            {
                this.Browser.Visibility = Visibility.Collapsed;
                this.FetchFirebaseData(oauthResult.AccessToken, FirebaseAuthType.Facebook);
            }
        }

        private async void FetchFirebaseData(string accessToken, FirebaseAuthType authType)
        {
            try
            {
                // Convert the access token to firebase token
                auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAppKey));
                data = await auth.SignInWithOAuthAsync(authType, accessToken);

                // Setup FirebaseClient to use the firebase token for data requests
                whodis = data.User.LocalId;
                db = new FirebaseClient(
                       FirebaseAppUri,
                       new FirebaseOptions
                       {
                           AuthTokenAsyncFactory = () => Task.FromResult(data.FirebaseToken)
                       });

                // TODO: your path within your DB structure.
                var dbData = await db
                    .Child("userGroups")
                    .Child(data.User.LocalId)
                    //.Child(Nam)
                    .OnceAsync<object>(); // TODO: custom class to represent your data instead of just object

                // TODO: present your data
                MessageBox.Show("Logged in!");
                InformationProject4._5.Information.loginSuccesful = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed :( \n" + ex);
                InformationProject4._5.Information.loginSuccesful = false;
            }
        }

        private async void DataSendClick(object sender, RoutedEventArgs e)
        {
            if (InformationProject4._5.Information.loginSuccesful == true && InformationProject4._5.Information.allowDataSend) //checks if the user is logged in succesful and the game has been exited
            {
                Punten test = new Punten();
                test.setPunten(InformationProject4._5.Information.totaalPunten);

                await db.Child(data.User.LocalId).Child("Punten").Child("Punten").PutAsync(test); // sends the data to the database on the associated branch

                Skins skins = new Skins();
                skins.setSkins(InformationProject4._5.Information.skinsAvailable); //information available skins

                await db.Child(data.User.LocalId).Child("Skins").Child("Skins").PutAsync(skins);

                Speeds speeds = new Speeds();
                speeds.setSpeeds((int)InformationProject4._5.Information.movementSpeed); // informatie van movement snelheid

                await db.Child(data.User.LocalId).Child("Speeds").Child("Speeds").PutAsync(speeds);

            }
            else
            {
                MessageBox.Show("Please play and exit the game first"); //if unsuccesful, shows a message box 
            }

        }

        private async void DataRetrieveClick(object sender, RoutedEventArgs e)
        {
            if (InformationProject4._5.Information.loginSuccesful == true)
            {
                var puntjes = await db.Child(data.User.LocalId)
                .Child("Punten")
                .OnceAsync<Punten>(); //loads the information from the database

                foreach (var punt in puntjes) //loops through the information on that branch in the database and writes it to the information class
                {
                    InformationProject4._5.Information.totaalPunten = punt.Object.punten;
                    Console.WriteLine($"{punt.Key} is {punt.Object.punten}");

                }
                var speedjes = await db.Child(data.User.LocalId)
               .Child("Speeds")
               .OnceAsync<Speeds>();

                foreach (var speed in speedjes)
                {
                    InformationProject4._5.Information.movementSpeed = speed.Object.speeds;
                    Console.WriteLine($"{speed.Key} is {speed.Object.speeds}");

                }
                var skintjes = await db.Child(data.User.LocalId)
               .Child("Skins")
               .OnceAsync<Skins>();

                foreach (var skin in skintjes)
                {
                    InformationProject4._5.Information.skinsAvailable = skin.Object.skins; 
                    Console.WriteLine($"{skin.Key} is {skin.Object.skins}");

                }

                // this.Hide(); //its possible to hide the login screen
                threadStart(); //starts the thread of the game
            }
            else
            {
                MessageBox.Show("Please log in first!");
            }

        }

        public void threadStart()
        {
            Thread gameThread = new Thread(StartGame);
            gameThread.Start();
        }

        public void StartGame()
        {
            SpeedTop4._5.Program.Main(null);
        }


    }
}
