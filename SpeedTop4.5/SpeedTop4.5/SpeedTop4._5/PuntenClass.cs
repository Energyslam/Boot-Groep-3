using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedTop4._5
{
    public class PuntenClass : TextGameObject
    {

        public PuntenClass() : base("GameFont")
        {
            text = "Total Points " + InformationProject4._5.Information.totaalPunten;
            this.position = new Vector2(10, 10);
        }
    }
}
