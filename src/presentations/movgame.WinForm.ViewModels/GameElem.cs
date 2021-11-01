using System;
using System.Drawing;

namespace movgame.WinForm.ViewModels
{
    public abstract class GameElem
    {
        public Game game;
        public int typ, dir, x, y, r, c;
        public bool reached = false;

        public const int ROAD = 0;
        public const int WALL = 1;
        public const int PLAYER = 2;
        public const int ALIEN = 3;

        public GameElem(Game game)
        {
            this.game = game;
        }

        public void SetPos(int x1, int y1)
        {
            x = x1;
            y = y1;
            r = y / game.uh;
            c = x / game.uw;
            reached = (y % game.uh == 0 && x % game.uw == 0);
        }

        public virtual void Draw(Graphics g) { }
        public abstract void Move();



    }
}
