using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Models.Characters
{
    public class Alien : CharacterBase
    {
        #region フィールド
        /// <summary>
        /// 乱数
        /// </summary>
        protected static Random rnd = new Random();
        protected int nextDirection = 0;
        protected int[,] dirOffset = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        static Brush brush = new SolidBrush(Color.IndianRed);
        int[] tryPlan = { 1, 3, 2 };
        #endregion

        public override int TypeCode { get; protected set; } = ALIEN;

        public Alien(GameEngine gameEngine) : base(gameEngine)
        {
        }

        #region メソッド
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, X + 2, Y + 2, GameEngine.unitWidth - 4, GameEngine.unitHeight - 4);
        }
        /// <summary>
        /// 移動先を設定
        /// </summary>
        public virtual void NextMove()
        {
            NextMoveRandom();
        }
        /// <summary>
        /// ランダムな方向転換による移動
        /// </summary>
        public void NextMoveRandom()
        {
            nextDirection = rnd.NextDouble() < 0.005 ? (direction + 1 + (int)((rnd.NextDouble() * 2) + 0.5)) % 4 : direction;
        }

        /// <summary>
        /// 移動実行処理
        /// </summary>
        public void MoveExec()
        {
            var x1 = X + dirOffset[nextDirection, 0];
            var y1 = Y + dirOffset[nextDirection, 1];
            if (GameEngine.IsWall(x1, y1) || GameEngine.GetCollision(this, x1, y1) != -1)
            {
                nextDirection = (nextDirection + tryPlan[(int)(rnd.NextDouble() * 2.1)]) % 4;
                x1 = X + dirOffset[nextDirection, 0];
                y1 = Y + dirOffset[nextDirection, 1];
            }
            if (!GameEngine.IsWall(x1, y1) && GameEngine.GetCollision(this, x1, y1) == -1)
            {
                direction = nextDirection;
                SetPos(x1, y1);
            }
        }


        public override void Move()
        {
            NextMove();
            MoveExec();
        }
        #endregion

    }
}
