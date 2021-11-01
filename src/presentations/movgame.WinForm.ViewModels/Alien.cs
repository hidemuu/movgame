using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.WinForm.ViewModels
{
    public class Alien : GameElem
    {
        protected static Random rnd = new Random();
        protected int nextDir = 0;
        protected int[,] dirOffset = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        static Brush br = new SolidBrush(Color.IndianRed);
        int[] tryPlan = { 1, 3, 2 };

        public Alien(Game game) : base(game)
        {
            typ = ALIEN;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(br, x + 2, y + 2, game.uw - 4, game.uh - 4);
        }

        public virtual void NextMove()
        {
            NextMoveRandom();
        }

        public void NextMoveRandom()
        {
            nextDir = rnd.NextDouble() < 0.005 ? (dir + 1 + (int)((rnd.NextDouble() * 2) + 0.5)) % 4 : dir;
        }

        public void MoveExec()
        {
            var x1 = x + dirOffset[nextDir, 0];
            var y1 = y + dirOffset[nextDir, 1];
            if (game.IsWall(x1, y1) || game.GetCollision(this, x1, y1) != -1)
            {
                nextDir = (nextDir + tryPlan[(int)(rnd.NextDouble() * 2.1)]) % 4;
                x1 = x + dirOffset[nextDir, 0];
                y1 = y + dirOffset[nextDir, 1];
            }
            if (!game.IsWall(x1, y1) && game.GetCollision(this, x1, y1) == -1)
            {
                dir = nextDir;
                SetPos(x1, y1);
            }
        }

        public override void Move()
        {
            NextMove();
            MoveExec();
        }

    }
}
