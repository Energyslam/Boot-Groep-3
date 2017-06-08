using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class Player : SpriteGameObject
    {
        public static string playerSprite = "normaalNormaal"; 
        public float movementSpeed = InformationProject4._5.Information.movementSpeed;
        int playerNumber;
        public bool playingState; //checks whether you are in playingstate or customizationstate
        string assetName = "";
        public Player(Vector2 positie, int playerNummer, string assetName) : base(assetName)
        {
            position = positie;
            playerNumber = playerNummer;
            this.assetName = assetName;
            origin = Center;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (playingState == true)
            {
                if (playerNumber == 1 && InformationProject4._5.Information.isServer == true || playerNumber == 1 && InformationProject4._5.Information.isPlayer1 == true)
                {
                    if (inputHelper.IsKeyDown(Keys.Right)) position.X += movementSpeed;
                    if (inputHelper.IsKeyDown(Keys.Left)) position.X -= movementSpeed;
                    if (inputHelper.IsKeyDown(Keys.Up)) position.Y -= movementSpeed;
                    if (inputHelper.IsKeyDown(Keys.Down)) position.Y += movementSpeed;
                }
                if (playerNumber == 2 && InformationProject4._5.Information.isClient == true)
                {
                    if (inputHelper.IsKeyDown(Keys.Right))
                    {
                        position.X += movementSpeed; //MAX D to Right
                        Console.WriteLine(InformationProject4._5.Information.movementSpeed);
                    }
                    if (inputHelper.IsKeyDown(Keys.Left)) position.X -= movementSpeed; //MAX A to Left 
                    if (inputHelper.IsKeyDown(Keys.Up)) position.Y -= movementSpeed; //MAX W to Up
                    if (inputHelper.IsKeyDown(Keys.Down)) position.Y += movementSpeed; //MAX S to Down
                }

                position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - Width);
                position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y - Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            movementSpeed = InformationProject4._5.Information.movementSpeed;
            if (playerNumber == 1) sprite = new SpriteSheet(playerSprite);
        }
        // Deze methodes zetten de sprite naar de sprite die we willen
        public void changeSpriteto1() 
        {
            this.sprite = new SpriteSheet("normaalNormaal");
        }
        public void changeSpritetoNDun()
        {
            this.sprite = new SpriteSheet("dunNormaal");
        }

        public void changeSpritetoNDik()
        {
            this.sprite = new SpriteSheet("dikNormaal");
        }
        public void changeSpritetoMondDun()
        {
            this.sprite = new SpriteSheet("dunMondje");
        }

        public void changeSpritetoMondNormaal()
        {
            this.sprite = new SpriteSheet("normaalMondje");
        }

        public void changeSpritetoMondDik()
        {
            this.sprite = new SpriteSheet("grootMondje");
        }

        public void changeSpritetoDunFemale()
        {
            this.sprite = new SpriteSheet("dunFemale");
        }
        public void changeSpritetoNormaalFemale()
        {
            this.sprite = new SpriteSheet("normaalFemale");
        }
        public void changeSpritetoDikFemale()
        {
            this.sprite = new SpriteSheet("dikFemale");
        }
        public void changeSpriteto2()
        {
            this.sprite = new SpriteSheet("spr_player");
        }

        public void changeSpriteto3()
        {
            this.sprite = new SpriteSheet("spr_playerOption3");
        }

        public string changeSprite
        {
            get { return playerSprite; }
            set { playerSprite = value; }
        }
    }
}
