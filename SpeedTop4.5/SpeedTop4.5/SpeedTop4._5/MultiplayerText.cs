using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class MultiplayerText : TextGameObject
    {

        public MultiplayerText(int i, Vector2 positie) : base("GameFont")
        {
            if (i == 1) text = "Host";
            if (i == 2) text = "Client";
            Position = positie;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
    }
}
