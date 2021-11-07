using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Models.Characters
{
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    public class Player : CharacterBase
    {
        #region フィールド

        static Brush brush = new SolidBrush(Color.CornflowerBlue);
        int lastDx = -1;
        int lastDy = -1;

        #endregion

        public override int TypeCode { get; protected set; } = PLAYER;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        public Player(GameEngine gameEngine) : base(gameEngine)
        {
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, X + 2, Y + 2, GameEngine.UnitWidth - 4, GameEngine.UnitHeight - 4);
        }

        public override void Move()
        {
            var dx = 0;
            var dy = 0;

            if(GameEngine.KeyCode == 0)
            {
                //  キーが離された後の状態
                if (X % GameEngine.UnitWidth != 0 || Y % GameEngine.UnitHeight != 0)
                {
                    //1マスの中間位置は移動継続
                    dx = lastDx;
                    dy = lastDy;
                }
                else
                {
                    GameEngine.KeyCode = 0;
                    return;
                }
            }
            else
            {
                //押されているキーに対する処理
                switch (GameEngine.KeyCode)
                {
                    case GameEngine.KEY_CODE_LEFT: dx = -1; break;
                    case GameEngine.KEY_CODE_RIGHT: dx = 1; break;
                    case GameEngine.KEY_CODE_UP: dy = -1; break;
                    case GameEngine.KEY_CODE_DOWN: dy = 1; break;
                    default: return;
                }
            }

            //壁でなく他のキャラに衝突しなければ進む
            var x1 = X + dx;
            var y1 = Y + dy;
            if (!GameEngine.IsWall(x1, y1) && GameEngine.GetCollision(this, x1, y1) == -1)
            {
                SetPosition(x1, y1);
                lastDx = dx;
                lastDy = dy;
            }

        }
    }
}
