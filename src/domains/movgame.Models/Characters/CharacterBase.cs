﻿using System;
using System.Drawing;

namespace movgame.Models.Characters
{
    /// <summary>
    /// キャラクター基本クラス
    /// </summary>
    public abstract class CharacterBase
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

        /// <summary>
        /// 種類
        /// </summary>
        public abstract int TypeCode { get; protected set; }
        /// <summary>
        /// X座標
        /// </summary>
        public int X { get; protected set; }
        /// <summary>
        /// Y座標
        /// </summary>
        public int Y { get; protected set; }
        /// <summary>
        /// ゲームエンジン
        /// </summary>
        protected GameEngine GameEngine { get; private set; }
        /// <summary>
        /// 方向
        /// </summary>
        protected int direction;
        /// <summary>
        /// 行
        /// </summary>
        protected int row;
        /// <summary>
        /// 列
        /// </summary>
        protected int col;
        /// <summary>
        /// ユニット接触フラグ
        /// </summary>
        protected bool reached = false;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        public CharacterBase(GameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        #region メソッド

        /// <summary>
        /// 位置更新
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public void SetPos(int x1, int y1)
        {
            X = x1;
            Y = y1;
            row = Y / GameEngine.unitHeight;
            col = X / GameEngine.unitWidth;
            reached = Y % GameEngine.unitHeight == 0 && X % GameEngine.unitWidth == 0;
        }
        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Draw(Graphics graphics) { }
        /// <summary>
        /// 移動処理
        /// </summary>
        public abstract void Move();

        #endregion

    }
}