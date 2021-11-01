using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Models
{
    public class Player : Character
    {
        static Brush brush = new SolidBrush(Color.CornflowerBlue);
        int lastDx = -1;
        int lastDy = -1;

        public Player(GameEngine gameEngine) : base(gameEngine)
        {
            type = PLAYER;
        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x + 2, y + 2, gameEngine.unitWidth - 4, gameEngine.unitHeight - 4);
        }

        public override void Move()
        {
            var dx = 0;
            var dy = 0;

            if(gameEngine.keyCode == 0)
            {
                //  キーが離された後の状態
                if (x % gameEngine.unitWidth != 0 || y % gameEngine.unitHeight != 0)
                {
                    //1マスの中間位置は移動継続
                    dx = lastDx;
                    dy = lastDy;
                }
                else
                {
                    gameEngine.keyCode = 0;
                    return;
                }
            }
            else
            {
                //押されているキーに対する処理
                switch (gameEngine.keyCode)
                {
                    case GameEngine.LEFT: dx = -1; break;
                    case GameEngine.RIGHT: dx = 1; break;
                    case GameEngine.UP: dy = -1; break;
                    case GameEngine.DOWN: dy = 1; break;
                    default: return;
                }
            }

            //壁でなく他のキャラに衝突しなければ進む
            var x1 = x + dx;
            var y1 = y + dy;
            if (!gameEngine.IsWall(x1, y1) && gameEngine.GetCollision(this, x1, y1) == -1)
            {
                SetPos(x1, y1);
                lastDx = dx;
                lastDy = dy;
            }

        }
    }
}
