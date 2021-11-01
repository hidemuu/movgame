using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace movgame.WinForm.ViewModels
{
    public class Player : GameElem
    {
        static Brush br = new SolidBrush(Color.CornflowerBlue);
        int lastDx = -1;
        int lastDy = -1;

        public Player(Game game) : base(game)
        {
            typ = PLAYER;
        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(br, x + 2, y + 2, game.uw - 4, game.uh - 4);
        }

        public override void Move()
        {
            var dx = 0;
            var dy = 0;

            if(game.keyCode == 0)
            {
                if (x % game.uw != 0 || y % game.uh != 0)
                {
                    dx = lastDx;
                    dy = lastDy;
                }
                else
                {
                    game.keyCode = 0;
                    return;
                }
            }
            else
            {
                switch (game.keyCode)
                {
                    case Keys.Left: dx = -1; break;
                    case Keys.Right: dx = 1; break;
                    case Keys.Up: dy = -1; break;
                    case Keys.Down: dy = 1; break;
                    default: return;
                }
            }

            var x1 = x + dx;
            var y1 = y + dy;
            if (!game.IsWall(x1, y1) && game.GetCollision(this, x1, y1) == -1)
            {
                SetPos(x1, y1);
                lastDx = dx;
                lastDy = dy;
            }

        }
    }
}
