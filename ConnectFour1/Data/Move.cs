using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Move
    {
        private int _row;
        private int _col;
        private Player _current;

        public Move(int r, int c, Player p)
        {
            _row = r;
            _col = c;
            _current = p;
        }
        public int Row { get => _row; set => _row = value; }
        public int Col { get => _col; set => _col = value; }
        public Player Current { get => _current; set => _current = value; }
    }
}
