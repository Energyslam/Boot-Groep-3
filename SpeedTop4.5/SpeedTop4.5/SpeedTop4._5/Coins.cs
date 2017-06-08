using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class Coins : TextGameObject
    {
        public Coins() : base("GameFont")
        {
            text = "Coins    " + InformationProject4._5.Information.totaalPunten; 
        }
    }
}
