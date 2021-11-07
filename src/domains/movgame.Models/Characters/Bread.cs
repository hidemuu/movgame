using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Models.Characters
{
    public class Bread : CharacterBase
    {
        public override int TypeCode { get; protected set; } = BREAD;
        static Brush brush = new SolidBrush(Color.CornflowerBlue);

        public Bread(GameEngine gameEngine) : base(gameEngine)
        {
            SetPosition(-100, -100);
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, X - 2, Y - 2, 4, 4);
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
