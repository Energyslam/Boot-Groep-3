using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class Score : TextGameObject
    {
        int positie;
        public int score = 0;
        public int elo = 0; 
        public Score(int i) : base("GameFont")
        {
            positie = i;
            if (positie == 1)
            {
                position = new Vector2(GameEnvironment.Screen.X / 5, GameEnvironment.Screen.Y / 5);
                text = "Player1\n" + score;
            }
            if (positie == 2)
            {
                position = new Vector2(GameEnvironment.Screen.X / 5 * 4, GameEnvironment.Screen.Y / 5);
                text = "Player2\n" + score;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (positie == 1)
            {
                text = "Player1\n" + score;
            }
            if (positie == 2)
            {
                text = "Player2\n" + score;
            }
        }
        public void scoreUpdate(int i)
        {
            score += i;
        }

        public void PuntenBerekenen() // De punten berekent met de punten van een match
        {
            InformationProject4._5.Information.totaalPunten += elo;
        }
    }
}
