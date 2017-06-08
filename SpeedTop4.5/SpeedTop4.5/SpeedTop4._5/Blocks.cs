using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class Block : SpriteGameObject
    {
        public Block(Vector2 positie) : base("spr_hamburger")
        {
            position.X = positie.X;
            position.Y = positie.Y;
        }
    }
}
