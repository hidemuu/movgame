using movgame.Repository;
using movgame.Repository.InMemory;
using movgame.Repository.Txt;
using movgame.WinForm.ViewModels;
using movgame.WinForm.ViewModels.Services;
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
        protected GameService service;
        protected ILandMarkRepository landMarkRepository;

        public Form1()
        {
            InitializeComponent();
        }

        protected virtual void Init()
        {
            landMarkRepository = new InMemoryLandMarkRepository();
            service = new GameService(this, landMarkRepository);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            service.Run();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.End();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            service.Draw(e.Graphics);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            service.SetKeyCode((int)e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            service.SetKeyCode(0);
        }
    }
}
