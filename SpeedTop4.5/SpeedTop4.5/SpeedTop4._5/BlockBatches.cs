using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpeedTop4._5
{
    class BlockBatches : GameObjectList
    {
        public GameObjectList blocks = new GameObjectList();
        int blockCounter = 0; //counts up to blockCounterSpawn with 1 per frame, then resets
        int superHiddenServerCounter = 0; //extra counter for the server, rolls earlier so client and server spawn the same batch
        public Vector2 blockVelocity = new Vector2(0, InformationProject4._5.Information.gameStartSpeed);
        int spawn;
        //velocity and blockcounter are exact opposites so room in between rows is constant;
        float maximumVelocity = 300; //maximum speed of rows coming down
        float minimumSpawnTime = 50; //minimum time between row spawns
        Block block = new Block(new Vector2(GameEnvironment.Screen.X / 2, 0));
        double blockCounterSpawn = 300; //When number is reached, spawns a row of blocks. Gets reduced every frame
        float velocityIncrease = 1.0005f; //velocity gets multiplied by this number each frame
        float blockCounterSpawnDecrease = 0.9995f; //spawntime multiplied by this number each frame
        
        public BlockBatches()
        {
            this.Add(blocks);
            BlockBatch1();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (blockVelocity.Y <= maximumVelocity) blockVelocity *= velocityIncrease; //increased velocity each frame
            if (blockVelocity.Y > maximumVelocity) blockVelocity = new Vector2(0, maximumVelocity); //checks whether the velocity is higher than the maximum, else sets it back to the maximum
            if (blockCounterSpawn > minimumSpawnTime) blockCounterSpawn *= blockCounterSpawnDecrease;
            if (blockCounterSpawn <= minimumSpawnTime) blockCounterSpawn = minimumSpawnTime;
            blockCounter += 1; //adds one to the blockcounter, gets reset once a certain number has been reached
            superHiddenServerCounter += 1;
            if (InformationProject4._5.Information.isPlayer1 || InformationProject4._5.Information.isServer) //checks whether the player is either playing alone or acting as a host
            {
                if (superHiddenServerCounter > blockCounterSpawn - 10) //10 less than the normal one, so it rolls before the client and both align with the same batches
                {
                    spawn = Game1.Random.Next(1, 7);
                    InformationProject4._5.Information.spawn = spawn; //sends the random number to the information project. value gets sent to the client to spawn this batch
                    superHiddenServerCounter = 10;
                }
                if (blockCounter >= blockCounterSpawn) //if counter is larger than the set amount, spawns a block
                {
                   
                    
                    switch (spawn)
                    {
                        case 1:
                            BlockBatch1();
                            break;
                        case 2:
                            BlockBatch2();
                            break;
                        case 3:
                            BlockBatch3();
                            break;
                        case 4:
                            BlockBatch4();
                            break;
                        case 5:
                            BlockBatch5();
                            break;
                        case 6:
                            BlockBatch6();
                            break;
                    }
                    blockCounter = 0; //sets the counter back to 0
                }
            }

            if (InformationProject4._5.Information.isClient == true) 
            {
                if (blockCounter >= blockCounterSpawn) //if counter is larger than the set amount, spawns a block
                {
                    switch (InformationProject4._5.Information.spawn)
                    {
                        case 1:
                            BlockBatch1();
                            break;
                        case 2:
                            BlockBatch2();
                            break;
                        case 3:
                            BlockBatch3();
                            break;
                        case 4:
                            BlockBatch4();
                            break;
                        case 5:
                            BlockBatch5();
                            break;
                        case 6:
                            BlockBatch6();
                            break;
                    }
                    blockCounter = 0;
                }
            }
        }

        public void BlockBatch1()
        {
            for (int i = 0; i < 4; i++)
            {
                blocks.Add(new Block(new Vector2(0 + i * GameEnvironment.Screen.X / 4, -100)));
            }
        }

        public void BlockBatch2()
        {
            for (int i = 0; i < 4; i++)
            {
                blocks.Add(new Block(new Vector2(block.Width / 2 + i * GameEnvironment.Screen.X / 4, -100)));
            }
        }

        public void BlockBatch3()
        {
            for (int i = 0; i < 4; i++)
            {
                blocks.Add(new Block(new Vector2(block.Width + i * GameEnvironment.Screen.X / 4, -100)));
            }
        }

        public void BlockBatch4()
        {
            blocks.Add(new Block(new Vector2(0, -100)));
            blocks.Add(new Block(new Vector2(0 + block.Width, -100)));
            blocks.Add(new Block(new Vector2(0 + block.Width * 2, -100)));
            blocks.Add(new Block(new Vector2(GameEnvironment.Screen.X - block.Width, -100)));
            blocks.Add(new Block(new Vector2(GameEnvironment.Screen.X - 2 * block.Width, -100)));
            blocks.Add(new Block(new Vector2(GameEnvironment.Screen.X - 3 * block.Width, -100)));

        }

        public void BlockBatch5()
        {
            for (int i = 2; i < 6; i++)
            {
                blocks.Add(new Block(new Vector2(0 + i * block.Width, -100)));
            }
        }

        public void BlockBatch6()
        {
            blocks.Add(new Block(new Vector2(0, -100)));
            blocks.Add(new Block(new Vector2(GameEnvironment.Screen.X - block.Width, -100)));
            blocks.Add(new Block(new Vector2(block.Width, -125)));
            blocks.Add(new Block(new Vector2(GameEnvironment.Screen.X - block.Width * 2, -125)));
            blocks.Add(new Block(new Vector2(block.Width * 2, -150)));
            blocks.Add(new Block(new Vector2(GameEnvironment.Screen.X - block.Width * 3, -150)));
        }

        public override void Reset()
        {
            base.Reset();
            blockVelocity = new Vector2(0, 50);
            blockCounter = 0;
            blockCounterSpawn = 300;
        }
    }
}
