using movgame.WinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movgame.WinForm
{
    public partial class Form1 : Form
    {
        protected Game game;

        public Form1()
        {
            InitializeComponent();
        }

        protected virtual void Init()
        {
            game = new Game(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            game.Run();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.End();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.keyCode = e.KeyCode;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            game.keyCode = 0;
        }
    }
}
