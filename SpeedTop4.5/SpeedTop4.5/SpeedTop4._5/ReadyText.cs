using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class ReadyText : TextGameObject
    {
        public ReadyText(int player1, int player2, Vector2 position, bool isplayer1) : base("GameFont")
        {

            
            Position = position;
            //achteraf gezien was het niet nodig om de text in de class al neer te zetten. Maar de text toe te voegen wanneer we de text in de readyUpGameState initialiseren.
            text = "Ready ? \n" + "press Enter to ready up";
            if (isplayer1 && player1 == 0 && player2 == 1)
                text = "Ready? \n" + "press Enter to ready up";
            if (isplayer1 && player1 == 1 && player2 == 0)
                text = "You are ready, waiting for opponent to ready up";
            if (isplayer1 == false && player2 == 0 && player1 == 1)
                text = text = "Ready? \n" + "press Enter to ready up";
            if (isplayer1 == false && player2 == 1 && player1 == 0)
                text = "You are ready, waiting for opponent to ready up";

        }
    }
}
