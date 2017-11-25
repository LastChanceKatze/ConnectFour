using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameOverEventArgs: EventArgs
    {
        private GameState _state;

        public GameOverEventArgs(GameState stanje)
            :base()
        {
            _state = stanje;
        }

        public GameState State
        {
            get { return _state; }
        }
    }
}
