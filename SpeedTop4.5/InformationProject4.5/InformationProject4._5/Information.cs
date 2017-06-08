using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationProject4._5
{
    public static class Information
    {
        //customization
        public static bool exitGame = false;
        public static int coins = 300;
        public static float movementSpeed = 5;
        public static float gameStartSpeed = 50;
        public static int totaalPunten = 320;
        public static int customizationNumber = 1;
        public static int matchPunten = 25;
        //netwerk
        public static string ipAdres = "127.0.0.1";
        public static bool isPlayer1 = true;
        public static bool isClient = false;
        public static bool isServer = false;
        public static bool twoPlayers = false;
        public static bool addPlayerTwo = false;
        public static string messagePlayerOne = 0 + " " + 0 + " " + 1 + " " + 0; //message has to be hardcoded with else the receiving side crashes before the string has been made in the toString
        public static string playerID = "";
        public static int readyP1 = 0; //readycheck
        public static int readyP2 = 0; //readycheck
        public static int spawn = 1; //server sends client which batch to spawn
        public static bool connectionStatus = true;
        public static bool allowDataSend = false; //login screen check if game is exited
        public static bool serverExit = false;

        //login
        public static bool showForm = false;
        public static bool loginSuccesful = false;

        //skin variabel
        public static int skinNormaal = 1; 
        public static int skinFemale = 0; 
        public static int skinp2 = 1; // 1 is normaal , 2 is female, 3 is mond
        public static int skinMond = 0; 
        public static int grensDun = 300; 
        public static int grensNorm = 200; 
        public static int grensDik = 100; 
        public static int skinsAvailable = 0; //1 is vrouw wel, mond niet | 2 is mond wel , vrouw niet | 3 is beiden wel
        public static bool fSkinGekocht = false;
        public static bool mSkinGekocht = false;
        public static bool nSkinGekocht = false;
        public static int volume = 1; //boolean whether music should play or not
       
        //initial player coordinates
        public static float player1X = 0;
        public static float player1Y = 0;
        public static float player2X = 400;
        public static float player2Y = 300;
    }
}
