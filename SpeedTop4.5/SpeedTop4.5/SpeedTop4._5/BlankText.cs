using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTop4._5
{
    class BlankText:TextGameObject //could have been used for everything instead of seperate text classes with switch cases but found this out at the complete end of the project
    {
        public BlankText() : base("GameFont")
        {
            text = "";
        }
    }
}
