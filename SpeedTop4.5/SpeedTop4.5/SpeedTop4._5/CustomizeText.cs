using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class CustomizeText : TextGameObject
    {
        public CustomizeText(int i, Vector2 positie) : base("GameFont")
        {
            if (i == 1)
            {
                text = "";
            }

            
            if (i == 2)
            {
                text = "";
            }

            if (i == 3)
            {
                text = "";
            }

            position = positie;
        }
    }
}
