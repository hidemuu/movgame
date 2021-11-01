using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Models
{
    public class Wall : Character
    {
        static Brush brush = new SolidBrush(Color.DarkGray);

        public Wall(GameEngine gameEngine) : base(gameEngine)
        {
            type = WALL;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, gameEngine.unitWidth, gameEngine.unitHeight);
        }

        public override void Move()
        {
            
        }

    }
}
