using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Player
    {
        private int id; //0- prvi igrac ili 1=drugi igrac

        public int Id {
            get { return id; }

        }

        public Player(int i) {
            id = i;
        }

        public abstract Move Play(int i);

    }
}
