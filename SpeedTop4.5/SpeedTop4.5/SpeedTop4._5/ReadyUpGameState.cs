using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpeedTop4._5
{
    class
        ReadyUpGameState : GameObjectList
    {
           SpriteGameObject background = new SpriteGameObject("spr_background");
        int readyChecker = 0;
        BlankText goBack = new BlankText();
        ReadyText rdyText = new ReadyText(InformationProject4._5.Information.readyP1, InformationProject4._5.Information.readyP2, new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 2), InformationProject4._5.Information.isServer);// ghyma de screen X
        public ReadyUpGameState()
        {
            

            goBack.Position = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 5 * 4);
            goBack.Text = "Press Space to go back";
              this.Add(background);
            
            
         
            Add(rdyText);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Enter) && InformationProject4._5.Information.isClient)
          
            {
                InformationProject4._5.Information.connectionStatus = true;
                InformationProject4._5.Information.readyP2 = 1;
                
            
                rdyText.Text = "You are ready, waiting for opponent to ready up";
                //ClientClass.Connect(InformationProject4._5.Information.ipAdres, messageComplete());
                

            }

            if (inputHelper.KeyPressed(Keys.Enter) && InformationProject4._5.Information.isServer)
            {
                InformationProject4._5.Information.readyP1 = 1;
                InformationProject4._5.Information.messagePlayerOne = 0 + " " + 0 + " " + 1 + " " + 1;
            
                rdyText.Text = "You are ready, waiting for opponent to ready up";
            }

            if (inputHelper.KeyPressed(Keys.Space)) Game1.GameStateManager.SwitchTo("menuState");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InformationProject4._5.Information.connectionStatus == false) rdyText.Text = "Failed to connect!\n press Space to go back";
            readyChecker += 1;
            if (readyChecker > 2)
            {
                if (InformationProject4._5.Information.readyP2 == 1 && InformationProject4._5.Information.isClient == true) ClientClass.Connect(InformationProject4._5.Information.ipAdres, messageComplete());
                readyChecker = 0;
            }


            if (InformationProject4._5.Information.readyP1 == 1
                && InformationProject4._5.Information.readyP2 == 1)
            
            {
                Game1.GameStateManager.SwitchTo("playingState");
               
            }
        }

        public String messageComplete() //De message met informatie die de client mee geeft.
        {

            return InformationProject4._5.Information.player2X + " " + InformationProject4._5.Information.player2Y + " " + InformationProject4._5.Information.readyP2 + " " + InformationProject4._5.Information.skinp2;
        }
    }
}
