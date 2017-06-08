using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpeedTop4._5
{
    class MultiplayerState : GameObjectList
    {
        int arrowPosition = 1;
        SpriteGameObject multiplayerArrow = new SpriteGameObject("spr_menuarrow");
        BlankText goBack = new BlankText();
        public MultiplayerState()
        {
            goBack.Position = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 5 * 4);
            goBack.Text = "Press Space to go back";
            
            this.Add(new SpriteGameObject("spr_background"));
            Add(goBack);
            multiplayerArrow.Origin = new Vector2(multiplayerArrow.Width / 2, multiplayerArrow.Height / 4);
            Add(new MultiplayerText(1, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 5)));
            Add(new MultiplayerText(2, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 5 * 3)));
            Add(multiplayerArrow);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space)) Game1.GameStateManager.SwitchTo("menuState");
            if (inputHelper.KeyPressed(Keys.Up) && arrowPosition > 1) arrowPosition -= 1;
            if (inputHelper.KeyPressed(Keys.Down) && arrowPosition < 2) arrowPosition += 1;
            if (arrowPosition == 1 && inputHelper.KeyPressed(Keys.Enter) && InformationProject4._5.Information.isClient == false)
            {
                InformationProject4._5.Information.isServer = true;
                InformationProject4._5.Information.twoPlayers = true;
                threadStart();
                Game1.GameStateManager.SwitchTo("readyupState"); 

            }
            if (arrowPosition == 2 && inputHelper.KeyPressed(Keys.Enter) && InformationProject4._5.Information.isServer == false)
            {
                InformationProject4._5.Information.isClient = true;
                InformationProject4._5.Information.isPlayer1 = false;
                InformationProject4._5.Information.twoPlayers = true;
                Game1.GameStateManager.SwitchTo("readyupState"); 
            }
            switch (arrowPosition)
            {
                case 1:
                    multiplayerArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - multiplayerArrow.Width, GameEnvironment.Screen.Y / 5);
                    break;
                case 2:
                    multiplayerArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - multiplayerArrow.Width, GameEnvironment.Screen.Y / 5 * 3);
                    break;
            }
        }

        public void threadStart() //start thread voor de server
        {
            Thread theThread = new Thread(StartGame);
            theThread.Start();
        }

        public void StartGame() //start server
        {
            Server4._5.Program.Main(null);
        }
    }
}
