using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Models.Characters
{
    public class Wall : CharacterBase
    {
        static Brush brush = new SolidBrush(Color.DarkGray);

        public override int TypeCode { get; protected set; } = WALL;

        public Wall(GameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, X, Y, GameEngine.unitWidth, GameEngine.unitHeight);
        }

        public override void Move()
        {
            
        }

    }
}
