using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Data;

namespace ConnectFour1
{
    public class Cell : Button
    {
        int _col;
        int _row;
        MainForm _parent;
        static ImageList _imageList = new ImageList{ };

        public int Col
        {
            get { return _col; }
        }

        public Player CurrentPlayer
        {
            set
            {
                //this.BackgroundImage = _imageList.Images[value.Id];
                this.Text = value.Id.ToString();
            }        
        }

        public Cell(int c, MainForm mf) 
            : base()
        {
            _col = c;
            _parent = mf;
            this.Height = 75;
            this.Width = 75;
            this.FlatStyle = FlatStyle.Flat;
            this.Margin = new Padding(0, 0, 0, 0);
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = this.BackColor;
            this.FlatAppearance.MouseOverBackColor = this.BackColor;
            //  this.BackgroundImage = _imageList.Images[2];
            this.Text = "-1";
        }

        protected override void OnClick(EventArgs e)
        {
            _parent.CallGame(this);
        }



    }
}
