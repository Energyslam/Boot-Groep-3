using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpeedTop4._5
{
    public class PlayingState : GameObjectList
    {
        ClientClass client = new ClientClass();
        SpriteGameObject background = new SpriteGameObject("spr_background");
        BlockBatches blockBatches = new BlockBatches();
        GameObjectList powerups = new GameObjectList();
        Player player1 = new Player(new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y - 100), 1, "spr_player");
        Player player2 = new Player(new Vector2(GameEnvironment.Screen.X / 3 * 2, GameEnvironment.Screen.Y - 100), 2, "normaalNormaal");
        Score scorePlayer1 = new Score(1);
        Score scorePlayer2 = new Score(2);
        int powerupCounter = 0;
        int powerupSpawner = 500;
        int powerupNumber = 1;
        string powerupSprite = "spr_powerup";
        int messageTimer = 0;
        string ipAdress = "127.0.0.1";

        public PlayingState()
        {
       //     switch (InformationProject4._5.Information.skinp2)
        //    {
        //        case 1:
        //            player2 = new Player(new Vector2(GameEnvironment.Screen.X / 3 * 2, GameEnvironment.Screen.Y - 100), 2, "normaalNormaal");
         //           break;
         //       case 2:
         //           player2 = new Player(new Vector2(GameEnvironment.Screen.X / 3 * 2, GameEnvironment.Screen.Y - 100), 2, "normaalFemale");
           //         break;
          //      case 3:
           //         player2 = new Player(new Vector2(GameEnvironment.Screen.X / 3 * 2, GameEnvironment.Screen.Y - 100), 2, "normaalMondje");
           //         break;
        //    }
            
            this.Add(client);
            this.Add(background);
            this.Add(blockBatches);
            this.Add(player1);
            //this.Add(player2);
            this.Add(scorePlayer1);
            
            this.Add(powerups);
            powerups.Add(new Powerup(new Vector2(Game1.Random.Next(0, GameEnvironment.Screen.X), -100), powerupNumber, powerupSprite));
            player1.playingState = true;
            player2.playingState = true;
            if (InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik)

                InformationProject4._5.Information.movementSpeed = InformationProject4._5.Information.movementSpeed * 0.5f;

            if (InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensNorm)
                InformationProject4._5.Information.movementSpeed = InformationProject4._5.Information.movementSpeed * 1f;

            if (InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun)
                InformationProject4._5.Information.movementSpeed = InformationProject4._5.Information.movementSpeed * 1.5f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            if (player1.Visible == true) scorePlayer1.scoreUpdate(1);
            if (player2.Visible == true) scorePlayer2.scoreUpdate(1);

            if (player1.Visible == false && player2.Visible == false)
            {
                Reset();
            }

            if (player1.Visible == false && InformationProject4._5.Information.isClient == false && InformationProject4._5.Information.isServer == false)
            {
                Reset();
            }
            //     if(InformationProject4._5.Information.skinFemale == 1)
            //     {
            //        if(InformationProject4._5.Information.isPlayer1)
            //        {
            //          player1.changeSpriteto1();
            //            player1.changeSprite ="normaalNormaal";
            //        }
            //  }


            if (InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.skinMond == 0 && InformationProject4._5.Information.skinFemale == 0)
            {
                player1.changeSpritetoNDik();
                player1.changeSprite = "dikNormaal";
            }


            if (InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun
                && InformationProject4._5.Information.skinMond == 0 && InformationProject4._5.Information.skinFemale == 0)
            {
                player1.changeSpritetoNDun();
                player1.changeSprite = "dunNormaal";
            }

            if (InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDun && InformationProject4._5.Information.skinMond == 0 && InformationProject4._5.Information.skinFemale == 0)
            {
                player1.changeSpriteto1();
                player1.changeSprite = "normaalNormaal";
            }


            if (InformationProject4._5.Information.customizationNumber == 2 && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik
              && InformationProject4._5.Information.skinFemale == 1)
            {
                player1.changeSpritetoDikFemale();
                player1.changeSprite = "dikFemale";

            }
            if (InformationProject4._5.Information.customizationNumber == 2
                && InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDun
              && InformationProject4._5.Information.skinFemale == 1)
            {
                player1.changeSpritetoNormaalFemale();
                player1.changeSprite = ("normaalFemale");
            }
            if (InformationProject4._5.Information.customizationNumber == 2
                && InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun
              && InformationProject4._5.Information.skinFemale == 1)
            {
                player1.changeSpritetoDunFemale();
                player1.changeSprite = "dunFemale";
            }


            if (InformationProject4._5.Information.customizationNumber == 3
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.skinMond == 1)
            {
                player1.changeSpritetoMondDik();
                player1.changeSprite = "grootMondje";
            }
            if (InformationProject4._5.Information.customizationNumber == 3
                && InformationProject4._5.Information.totaalPunten > InformationProject4._5.Information.grensDik
                && InformationProject4._5.Information.totaalPunten <= InformationProject4._5.Information.grensDun
                && InformationProject4._5.Information.skinMond == 1)
            {
                player1.changeSpritetoMondNormaal();
                player1.changeSprite = "normaalMondje";
            }
            if (InformationProject4._5.Information.customizationNumber == 3
                && InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun
                && InformationProject4._5.Information.skinMond == 1)
            {
                player1.changeSpritetoMondDun();
                player1.changeSprite = "dunMondje";
            }
            player1.movementSpeed = InformationProject4._5.Information.movementSpeed;
            player2.movementSpeed = InformationProject4._5.Information.movementSpeed;
            // this.position = -player1.Position; //Camera
            //uit client test
            //InformationProject.Information.positieX = player1.Position.X;
            //InformationProject.Information.positieY = player1.Position.Y;


            //     if(InformationProject4._5.Information.totaalPunten >= InformationProject4._5.Information.grensDun)
            //     InformationProject4._5.Information.movementSpeed = 1;

            if (InformationProject4._5.Information.isServer)
            {
                InformationProject4._5.Information.player1X = player1.Position.X;
                InformationProject4._5.Information.player1Y = player1.Position.Y;
            }
            if (InformationProject4._5.Information.isClient)
            {
                InformationProject4._5.Information.player2X = player2.Position.X;
                InformationProject4._5.Information.player2Y = player2.Position.Y;
            }
            if (InformationProject4._5.Information.twoPlayers)
            {
                Add(player2);
                Add(scorePlayer2);
                InformationProject4._5.Information.twoPlayers = false;
            }
            InformationProject4._5.Information.messagePlayerOne = messagePlayerOne();
            if (InformationProject4._5.Information.isServer) messagePlayerOne();
            messageTimer += 1; //MAX testing delay
            if (messageTimer > 1)
            {
                if (InformationProject4._5.Information.isClient == true)
                {
                    ClientClass.Connect(InformationProject4._5.Information.ipAdres, messageComplete());
                    if (InformationProject4._5.Information.isClient) player1.Position = new Vector2(InformationProject4._5.Information.player1X, InformationProject4._5.Information.player1Y);
                    messageTimer = 0;
                }

            }
            if (InformationProject4._5.Information.isClient) player1.Position = new Vector2(InformationProject4._5.Information.player1X, InformationProject4._5.Information.player1Y);
            if (InformationProject4._5.Information.isServer) player2.Position = new Vector2(InformationProject4._5.Information.player2X, InformationProject4._5.Information.player2Y);

            powerupCounter += 1;
            if (powerupCounter >= powerupSpawner)
            {
                powerups.Add(new Powerup(new Vector2(Game1.Random.Next(0, GameEnvironment.Screen.X - 50), -100), powerupNumber, powerupSprite));
                powerupCounter = 0;
            }
            background.Velocity = new Vector2(0, -3);
            foreach (Powerup p in powerups.Objects)
            {
                if (player1.CollidesWith(p))
                {
                    player1.movementSpeed += 1;
                    p.Visible = false;

                }
                if (player2.CollidesWith(p))
                {
                    player2.movementSpeed += 1;
                    p.Visible = false;

                    //scorePlayer1.elo -= 25; //ghyma
                    //scorePlayer2.elo += 25; //ghyma
                }

            }

            foreach (Block b in blockBatches.blocks.Objects)
            {
                b.Velocity = blockBatches.blockVelocity;

                if (player1.CollidesWith(b))
                {
                   // player1.Position = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y - 100);//crash
                    player1.Visible = false;
                    if (InformationProject4._5.Information.isPlayer1 == false)
                    {
                        scorePlayer2.elo += InformationProject4._5.Information.matchPunten;
                        scorePlayer1.elo -= InformationProject4._5.Information.matchPunten;
                        
                    }
                    
                }

                if (player2.CollidesWith(b))
                {
                   
                    player2.Visible = false;
                    if (InformationProject4._5.Information.isPlayer1)
                    {
                        scorePlayer1.elo += InformationProject4._5.Information.matchPunten;
                        scorePlayer2.elo -= InformationProject4._5.Information.matchPunten; 
                    }
                    
                }
            }
        }


        public override void Reset()
        {
            base.Reset();
            InformationProject4._5.Information.serverExit = true;
            scorePlayer1.score = 0;
            scorePlayer2.score = 0;
            background.Position = new Vector2(0, 0);
            powerupCounter = 0;
            
            blockBatches.Reset();
            blockBatches.blocks.Objects.Clear();
            if (InformationProject4._5.Information.twoPlayers) 
            {
                scorePlayer2.PuntenBerekenen();
            }
            else
            scorePlayer1.PuntenBerekenen();
            InformationProject4._5.Information.readyP1 = 0;
            InformationProject4._5.Information.readyP2 = 0;
            player2.Position = new Vector2(GameEnvironment.Screen.X / 3 * 2, GameEnvironment.Screen.Y - 100);
            player1.Position = new Vector2(GameEnvironment.Screen.X / 3, GameEnvironment.Screen.Y - 100);
            Game1.GameStateManager.SwitchTo("gameOverState");

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            

        }

        public String messageComplete()
        {

            return InformationProject4._5.Information.player2X + " " + InformationProject4._5.Information.player2Y + " " + InformationProject4._5.Information.readyP2 + " " + InformationProject4._5.Information.skinp2;
        }

        public String messagePlayerOne()
        {
            return InformationProject4._5.Information.player1X + " " + InformationProject4._5.Information.player1Y + " " + InformationProject4._5.Information.spawn + " " + InformationProject4._5.Information.readyP1;     
        }

        public void addPlayerTwo()
        {
            Add(player2);
        }
    }
}
