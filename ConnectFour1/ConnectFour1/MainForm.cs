using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace ConnectFour1
{
    public partial class MainForm : Form
    {
        int row = 6;
        int col = 7;
        Game game;

        public MainForm()
        {
            InitializeComponent();
            InitializeTlp();
            InitializeButtons();
            game = new Game();
            game.GameOver += GameOverHandle;
            //Player p1 = new Human(0);
            //Player p2 = new Human(1);


            ////p1.Play(1);
            ////p1.Play(1);           
            ////p1.Play(1);
            ////p2.Play(1);
            ////p1.Play(1);

            ////p1.Play(6);

            ////p1.Play(5);
            ////p2.Play(5);

            ////p1.Play(4);
            ////p1.Play(4);
            ////p2.Play(4);

            ////p1.Play(3);
            ////p1.Play(3);
            ////p1.Play(3);
            ////p2.Play(3);

            //for (int i = 0; i < 7; i++)
            //    for (int j = 0; j < 6; j++) {
            //        p1.Play(i);
            //    }
            //        Board.Instance.crtaj();
          
            //GameState s = Board.Instance.CheckWinner(p1);

        }

        private void InitializeTlp()
        {
            tlp.SuspendLayout();
            tlp.Controls.Clear();

            tlp.ColumnStyles.Clear();
            tlp.RowStyles.Clear();

            tlp.ColumnCount = col;
            tlp.RowCount = row;

            for (int i = 0; i < col; i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int j = 0; j < row; j++)
                {
                    if (i == 0)
                    {
                        tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                }
            }
            tlp.ResumeLayout();
        }
        private void InitializeButtons()
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    tlp.Controls.Add(new Cell(j,this), j, i);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void CallGame(Cell c) {

            Move lastMove = game.Play(c.Col);
            if (lastMove != null)
                ((Cell)tlp.GetControlFromPosition(lastMove.Col, lastMove.Row)).CurrentPlayer = lastMove.Current;
            if (game.State != GameState.NijeKraj)
                MessageBox.Show(game.State.ToString());
        }

        private void GameOverHandle(object sender, GameOverEventArgs e)
        {
            MessageBox.Show(e.State.ToString());
        }
    }
}
