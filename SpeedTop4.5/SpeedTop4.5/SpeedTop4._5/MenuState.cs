using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class MenuState : GameObjectList
    {
        public bool exitGame = false;
        int textSpacing = 6;
        int aantalTextObjects = 5;
        PuntenClass totaalPunten = new PuntenClass(); 
        Player dummyPlayer = new Player(new Vector2(50, 50), 2, "normaalNormaal"); 
        SpriteGameObject menuArrow = new SpriteGameObject("spr_menuarrow");
        Vector2 startPosition = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 6);
        Vector2 multiplayerPosition = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 6 * 2);
        Vector2 optionPosition = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 6 * 3);
        Vector2 customizePosition = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 6 * 4);
        Vector2 quitPosition = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y / 6 * 5);


        int arrowPosition = 1;

        public MenuState()
        {
            menuArrow.Origin = new Vector2(menuArrow.Width / 2, menuArrow.Height / 4);
            this.Add(new SpriteGameObject("spr_background"));
            this.Add(new MenuText(1, startPosition));
            this.Add(new MenuText(2, multiplayerPosition));
            this.Add(new MenuText(3, optionPosition));
            this.Add(new MenuText(4, customizePosition));
            this.Add(new MenuText(5, quitPosition));
            this.Add(menuArrow);
            this.Add(totaalPunten);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Up) && arrowPosition > 1) arrowPosition -= 1;
            if (inputHelper.KeyPressed(Keys.Down) && arrowPosition < aantalTextObjects) arrowPosition += 1;
            if (inputHelper.KeyPressed(Keys.Enter) && arrowPosition == 1)
            {
                Game1.GameStateManager.SwitchTo("playingState");
            }
            if (inputHelper.KeyPressed(Keys.Enter) && arrowPosition == 2) Game1.GameStateManager.SwitchTo("multiplayerState");
            if (inputHelper.KeyPressed(Keys.Enter) && arrowPosition == 3) Game1.GameStateManager.SwitchTo("optionState");
            if (inputHelper.KeyPressed(Keys.Enter) && arrowPosition == 4) Game1.GameStateManager.SwitchTo("customizationState");
            if (inputHelper.KeyPressed(Keys.Enter) && arrowPosition == 5)
            {
                InformationProject4._5.Information.allowDataSend = true;
                InformationProject4._5.Information.showForm = true;
                InformationProject4._5.Information.exitGame = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Omdat na gameoverstate de skins op basis van punten moeten kunnen worden aangepast, hebben we een dummyplayer in menuState. Zodat we bij de methodes van player kunnen.
            totaalPunten.Text = "Coins    " + InformationProject4._5.Information.totaalPunten;
            if (InformationProject4._5.Information.customizationNumber == 1 && InformationProject4._5.Information.totaalPunten <= 100) 
            {
                dummyPlayer.changeSpritetoNDik();
                dummyPlayer.changeSprite = "dikNormaal";
            }


            if (InformationProject4._5.Information.customizationNumber == 1 && InformationProject4._5.Information.totaalPunten > 300) 
            {
                dummyPlayer.changeSpritetoNDun();
                dummyPlayer.changeSprite = "dunNormaal";
            }

            if (InformationProject4._5.Information.customizationNumber == 1 && InformationProject4._5.Information.totaalPunten <= 200 && InformationProject4._5.Information.totaalPunten > 100) 
            {
                dummyPlayer.changeSpriteto1();
                dummyPlayer.changeSprite = "normaalNormaal";
            }
            switch (arrowPosition)
            {
                case 1:
                    menuArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - menuArrow.Width, GameEnvironment.Screen.Y / textSpacing);
                    break;
                case 2:
                    menuArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - menuArrow.Width, GameEnvironment.Screen.Y / textSpacing * 2);
                    break;
                case 3:
                    menuArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - menuArrow.Width, GameEnvironment.Screen.Y / textSpacing * 3);
                    break;
                case 4:
                    menuArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - menuArrow.Width, GameEnvironment.Screen.Y / textSpacing * 4);
                    break;
                case 5:
                    menuArrow.Position = new Vector2(GameEnvironment.Screen.X / 3 - menuArrow.Width, GameEnvironment.Screen.Y / textSpacing * 5);
                    break;

            }
        }
    }
}
