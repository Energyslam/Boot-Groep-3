using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class MenuText : TextGameObject
    {
        public MenuText(int textSelect, Vector2 positie) : base("GameFont")
        {
            switch (textSelect)
            {
                case 1:
                    text = "Practice game ";
                    break;
                case 2:
                    text = "Multiplayer";
                    break;
                case 3:
                    text = "Options";
                    break;
                case 4:
                    text = "Customization";
                    break;
                case 5:
                    text = "Quit";
                    break;
            }
            position = positie;
        }
    }
}
