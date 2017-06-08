using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    class Powerup : SpriteGameObject
    {
        private int powerUpSnelheid;
        public Powerup(Vector2 positie, int powerupNumber, string assetName) : base(assetName)
        {
            position = positie;
            velocity.Y = powerUpSnelheid;
        }
    }
}
