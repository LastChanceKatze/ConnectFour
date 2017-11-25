using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public enum BoardItem
    {
        Crveni  = 0,
        Zuti = 1,
        Empty = -1
    }

    public enum GameState
    {
        CrveniWin = 0,
        ZutiWin = 1,
        Nereseno = 2,
        NijeKraj = -1
    }

    public class Board
    {
        BoardItem[,] _matrix; //polja na tabli
        int[] _heightArray; // visine kolona
        int moves;
        static Board _instance = null; //singleton
        int row;
        int col;
        int lastMove;

        public static Board Instance {
            get {
                if (_instance == null)
                    _instance = new Board(6,7);
                return _instance;
            }
        }

        private Board(int m, int n) {
            row = m;
            col = n;
            _matrix = new BoardItem[m, n];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    _matrix[i, j] = BoardItem.Empty;
            _heightArray = new int[col];
            for(int i=0; i<col; i++)
            {
                _heightArray[i] = row - 1;
            }
            moves = 0;
            lastMove = -1;
            
        }

        //Pravi potez na tabli
        public Move MakeMove(int index, Player p)
        {
            if (_heightArray[index] < 0)
            {
                return null;
            }

            _matrix[_heightArray[index], index] = (BoardItem)p.Id;
            moves++;
            _heightArray[index]--;
            lastMove = index;
            return new Move(_heightArray[index]+1,index,p);
        }

        public GameState CheckWinner(Player p) {
            int m = _heightArray[lastMove] + 1;
            int n = lastMove;
            BoardItem stone = (BoardItem)p.Id;  //zheton

            //PROVERA KOLONE
            int buffer = 0;
            int i = m;
            while(i<row && buffer<4) {
                if (_matrix[i, n] == stone)
                    buffer++;
                else
                    buffer = 0;
                i++;
            }
            if (buffer == 4)
                return (GameState)p.Id;
            
            // PROVERA REDA
            buffer = 0;
            i = 0;
            while(i<col && buffer<4)
            {
                if (_matrix[m, i] == stone)
                    buffer++;
                else
                    buffer = 0;
                i++;
            }
            if (buffer == 4)
                return (GameState)p.Id;
            //PROVERA OPADAJUCE DIJAGONALE

            int mUp = m - Math.Min(m, (this.col - n - 1));
            int nUp = n + Math.Min(m, (this.col - n - 1));

            i = 0;
            buffer = 0;
            while (i < Math.Min(this.row - mUp, nUp + 1) && buffer<4) {
                if (_matrix[mUp + i, nUp - i] == stone)
                    buffer++;
                else
                    buffer = 0;
                i++;
            }

            if (buffer == 4)
                return (GameState)p.Id;

            //PROVERA RASTUCE DIJAGONALE

            int mDown = m - Math.Min(m, n);
            int nDown = n - Math.Min(m, n);

            i = 0;
            buffer = 0;
            while (i < Math.Min(this.row - mDown, this.col - nDown) && buffer < 4)
            {
                if (_matrix[mDown + i, nDown + i] == stone)
                    buffer++;
                else
                    buffer = 0;
                i++;
            }

            if (buffer == 4)
                return (GameState)p.Id;

            if (moves == 42)
                return GameState.Nereseno;

            return GameState.NijeKraj;
        }

        public void crtaj() {
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    Console.Write((int)_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
