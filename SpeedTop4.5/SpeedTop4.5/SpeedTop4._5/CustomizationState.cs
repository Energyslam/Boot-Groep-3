using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    
    class CustomizationState : GameObjectList
    {
        BlankText goBack = new BlankText();
        Player player = new Player(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2), 1, "spr_player");
        Coins coins = new Coins();
        SpriteGameObject menuArrow = new SpriteGameObject("spr_menuarrow");
        CustomizeText puntenTextplayerSpeed = new CustomizeText(1, new Vector2(50, 200)); 
        CustomizeText puntenTextstartSpeed = new CustomizeText(3, new Vector2(50, 400)); 
        CustomizeText puntenTextMinderSpeed = new CustomizeText(2, new Vector2(50, 300)); 
        CustomizeText skintext = new CustomizeText(1, new Vector2(50, 500)); 
        CustomizeText skinbought = new CustomizeText(1, new Vector2(500, 500)); 
        int menuArrowPosition; //saves the position of the arrow to check on which one it is
        int menuOffset = 100; 
        int aantalTextObjects = 3; 
        public CustomizationState()
        {
            goBack.Position = new Vector2(10, 10);
            goBack.Text = "Press Space\nto go back";
            
            Add(new SpriteGameObject("spr_background"));
            Add(goBack);
            Add(player);
            Add(coins);
            Add(menuArrow);
            menuArrowPosition = 0;
            Add(puntenTextplayerSpeed);
            Add(puntenTextstartSpeed); 
            Add(puntenTextMinderSpeed); 
            Add(skintext); 
            Add(skinbought); 
            coins.Position = new Vector2(GameEnvironment.Screen.X / 5 * 2, GameEnvironment.Screen.Y / 10);
            player.playingState = false;
            player.Position = new Vector2(GameEnvironment.Screen.X - (player.Width + menuOffset) / 2, GameEnvironment.Screen.Y / 5 * 4 - player.Height / 2); //ghyma
            skinbought.Text = "available"; 
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space)) Game1.GameStateManager.SwitchTo("menuState");

            if (inputHelper.KeyPressed(Keys.Left) && InformationProject4._5.Information.customizationNumber > 1 && menuArrowPosition == 3) InformationProject4._5.Information.customizationNumber -= 1; //ghyma

            if (inputHelper.KeyPressed(Keys.Right) && InformationProject4._5.Information.customizationNumber < 3 && menuArrowPosition == 3) InformationProject4._5.Information.customizationNumber += 1; //ghyma

            if (inputHelper.KeyPressed(Keys.Enter) && menuArrowPosition == 3 && InformationProject4._5.Information.customizationNumber == 2 && InformationProject4._5.Information.fSkinGekocht == false) //ghyma
            {                                                                                                                             //   {
                InformationProject4._5.Information.skinFemale = 1;
                InformationProject4._5.Information.totaalPunten -= 100;
                InformationProject4._5.Information.fSkinGekocht = true;   
            }

            if (inputHelper.KeyPressed(Keys.Enter) && menuArrowPosition == 3 && InformationProject4._5.Information.customizationNumber == 3 && InformationProject4._5.Information.mSkinGekocht == false)//ghyma
            {
                InformationProject4._5.Information.skinMond = 1;
                InformationProject4._5.Information.totaalPunten -= 100;
                InformationProject4._5.Information.mSkinGekocht = true;
                
            }

            if (inputHelper.KeyPressed(Keys.Enter) && menuArrowPosition == 0 && InformationProject4._5.Information.totaalPunten > 10) 
            {
                InformationProject4._5.Information.movementSpeed += 1; 
                InformationProject4._5.Information.totaalPunten -= 10; 
                if (InformationProject4._5.Information.totaalPunten < 0)
                    InformationProject4._5.Information.totaalPunten = 0;

                Console.WriteLine(InformationProject4._5.Information.movementSpeed); 
            }

            if (inputHelper.KeyPressed(Keys.Enter) && menuArrowPosition == 1 && InformationProject4._5.Information.totaalPunten > 10)
            {
                InformationProject4._5.Information.movementSpeed -= 1; 
                InformationProject4._5.Information.totaalPunten -= 20; 
                if (InformationProject4._5.Information.totaalPunten < 0)
                    InformationProject4._5.Information.totaalPunten = 0;

            }

            if (inputHelper.KeyPressed(Keys.Enter) && menuArrowPosition == 2 && InformationProject4._5.Information.totaalPunten > 10)
            {
                InformationProject4._5.Information.gameStartSpeed += 5;
                InformationProject4._5.Information.totaalPunten -= 50;
                if (InformationProject4._5.Information.totaalPunten < 0)
                    InformationProject4._5.Information.totaalPunten = 0;
            }

            if (inputHelper.KeyPressed(Keys.Up) && menuArrowPosition > 0)
            {
                menuArrowPosition -= 1;
            }

            if (inputHelper.KeyPressed(Keys.Down) && menuArrowPosition < aantalTextObjects) 
            {
                menuArrowPosition += 1;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            menuArrow.Position = new Vector2(0, 185 + menuArrowPosition * 100);
            puntenTextstartSpeed.Text = "Game starting speed\n      " + InformationProject4._5.Information.gameStartSpeed;
            puntenTextplayerSpeed.Text = "Player speed 1 for 10 coins\n     " + InformationProject4._5.Information.movementSpeed; 
            puntenTextMinderSpeed.Text = "Lower speed by 1 for 20\n      " + InformationProject4._5.Information.movementSpeed;
            skintext.Text = "Buy skin for 100";
                                               
            coins.Text = "Coins    " + InformationProject4._5.Information.totaalPunten;
            //Hier worden de skinsaangepast, afhankelijk van het customizationnumber

            if (InformationProject4._5.Information.customizationNumber == 1 && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik) //ghyma all the way to the bottom
                {
                player.changeSpritetoNDik();
                player.changeSprite = "dikNormaal";
              
            }


            if (InformationProject4._5.Information.customizationNumber == 1 && InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun)
            {
                player.changeSpritetoNDun();
                player.changeSprite = "dunNormaal";
              
            }

            if (InformationProject4._5.Information.customizationNumber == 1 && InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDun)
            {
                player.changeSpriteto1();
                player.changeSprite = "normaalNormaal";
              
            }


            if (InformationProject4._5.Information.customizationNumber == 2
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik)

            {
                player.changeSpritetoDikFemale();
                player.changeSprite = "dikFemale";


            }
            if (InformationProject4._5.Information.customizationNumber == 2
                && InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDun)

            {
                player.changeSpritetoNormaalFemale();
                player.changeSprite = ("normaalFemale");
            }
            if (InformationProject4._5.Information.customizationNumber == 2
                && InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun)

            {
                player.changeSpritetoDunFemale();
                player.changeSprite = "dunFemale";
            }


            if (InformationProject4._5.Information.customizationNumber == 3
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik)
            {
                player.changeSpritetoMondDik();
                player.changeSprite = "grootMondje";
            }
            if (InformationProject4._5.Information.customizationNumber == 3
                && InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDun)
            {
                player.changeSpritetoMondNormaal();
                player.changeSprite = "normaalMondje";
            }
            if (InformationProject4._5.Information.customizationNumber == 3
                && InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun)
            {
                player.changeSpritetoMondDun();
                player.changeSprite = "dunMondje";
            }
            if (InformationProject4._5.Information.skinNormaal == 1 && InformationProject4._5.Information.customizationNumber == 1)
            {
                skinbought.Text = "owned";
            }
            


            if (InformationProject4._5.Information.skinFemale == 1 && InformationProject4._5.Information.customizationNumber == 2)
            {
                skinbought.Text = "owned";
            }
            else if (InformationProject4._5.Information.customizationNumber == 2 && InformationProject4._5.Information.skinFemale == 0)
            {
                skinbought.Text = "available";
            }

            if (InformationProject4._5.Information.skinMond == 1 && InformationProject4._5.Information.customizationNumber == 3)
            {
                skinbought.Text = "owned";
            }
            else if (InformationProject4._5.Information.customizationNumber == 3 && InformationProject4._5.Information.skinMond == 0)
            {
                skinbought.Text = "available";
            }
            if (InformationProject4._5.Information.customizationNumber == 1)
                {


                    skinbought.Text = "owned";
                }

            if(InformationProject4._5.Information.fSkinGekocht && InformationProject4._5.Information.mSkinGekocht == false)
                InformationProject4._5.Information.skinsAvailable = 1;

            if (InformationProject4._5.Information.fSkinGekocht == false && InformationProject4._5.Information.mSkinGekocht)
                InformationProject4._5.Information.skinsAvailable = 2;

            if (InformationProject4._5.Information.fSkinGekocht && InformationProject4._5.Information.mSkinGekocht)
                InformationProject4._5.Information.skinsAvailable = 3;
            
            // hier wordt bepaald welke skins bij het nummer van skinsavailable variabel hoort
            if(InformationProject4._5.Information.skinsAvailable == 1)
            {
                InformationProject4._5.Information.skinFemale = 1;
            }
            if(InformationProject4._5.Information.skinsAvailable == 2)
            {
                InformationProject4._5.Information.skinMond = 1;
            }
            if(InformationProject4._5.Information.skinsAvailable == 3)
            {
                InformationProject4._5.Information.skinMond = 1;
                InformationProject4._5.Information.skinFemale = 1;
            }
            if (InformationProject4._5.Information.customizationNumber == 1)
                InformationProject4._5.Information.skinp2 = 1;

            if (InformationProject4._5.Information.customizationNumber == 2)
                InformationProject4._5.Information.skinp2 = 2;

            if (InformationProject4._5.Information.customizationNumber == 3)
                InformationProject4._5.Information.skinp2 = 3;
        }
            }
        
    }
