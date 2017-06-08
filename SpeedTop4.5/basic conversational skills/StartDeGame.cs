using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Firebase.Auth.Social
{
    class StartDeGame
    {
        public void threadStart()
        {
            Thread gameThread = new Thread(StartGame);
            gameThread.Start();
        }

        public void StartGame()
        {
            SpeedTop4._5.Program.Main(null);
        }
    }
}
