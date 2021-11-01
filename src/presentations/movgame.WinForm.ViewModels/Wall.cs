using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.WinForm.ViewModels
{
    public class Wall : GameElem
    {
        static Brush br = new SolidBrush(Color.DarkGray);

        public Wall(Game game) : base(game)
        {
            typ = WALL;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(br, x, y, game.uw, game.uh);
        }

        public override void Move()
        {
            
        }

    }
}
