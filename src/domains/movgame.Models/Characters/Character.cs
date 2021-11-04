using System;
using System.Drawing;

namespace movgame.Models.Characters
{
    /// <summary>
    /// キャラクター基本クラス
    /// </summary>
    public abstract class Character
    {
        #region 定数
        /// <summary>
        /// 道
        /// </summary>
        public const int ROAD = 0;
        /// <summary>
        /// 壁
        /// </summary>
        public const int WALL = 1;
        /// <summary>
        /// プレイヤー
        /// </summary>
        public const int PLAYER = 2;
        /// <summary>
        /// NPC
        /// </summary>
        public const int ALIEN = 3;
        #endregion

        #region フィールド
        public GameEngine gameEngine;
        /// <summary>
        /// 種類
        /// </summary>
        public int type;
        /// <summary>
        /// 方向
        /// </summary>
        public int direction;
        /// <summary>
        /// X座標
        /// </summary>
        public int x;
        /// <summary>
        /// Y座標
        /// </summary>
        public int y;
        /// <summary>
        /// 行
        /// </summary>
        public int row;
        /// <summary>
        /// 列
        /// </summary>
        public int col;
        /// <summary>
        /// ユニット接触フラグ
        /// </summary>
        public bool reached = false;
        #endregion

        public Character(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        #region メソッド
        /// <summary>
        /// 位置更新
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public void SetPos(int x1, int y1)
        {
            x = x1;
            y = y1;
            row = y / gameEngine.unitHeight;
            col = x / gameEngine.unitWidth;
            reached = (y % gameEngine.unitHeight == 0 && x % gameEngine.unitWidth == 0);
        }
        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g) { }
        /// <summary>
        /// 移動処理
        /// </summary>
        public abstract void Move();
        #endregion

    }
}
