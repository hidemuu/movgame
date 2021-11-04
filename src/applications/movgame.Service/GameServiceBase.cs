using movgame.Models;
using movgame.Models.Characters;
using movgame.Models.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace movgame.Service
{
    /// <summary>
    /// ゲームサービス基本クラス
    /// </summary>
    public abstract class GameServiceBase
    {
        #region フィールド

        /// <summary>
        /// ゲームスレッド
        /// </summary>
        private Task task;
        /// <summary>
        /// スレッド継続フラグ
        /// </summary>
        private bool active = true;
        
        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private GameEngine gameEngine;

        #endregion

        #region プロパティ

        /// <summary>
        /// 画面幅
        /// </summary>
        public int FrameWidth { get; private set; }
        /// <summary>
        /// 画面高さ
        /// </summary>
        public int FrameHeight { get; private set; }
        /// <summary>
        /// ビットマップ画面作成中フラグ
        /// </summary>
        public bool IsBuilding { get; private set; } = false;

        #endregion

        #region 抽象プロパティ

        public abstract Color BackgroundColor { get; set; }

        #endregion

        public GameServiceBase()
        {
            gameEngine = new GameEngine();
            FrameWidth = GameMap.col * gameEngine.unitWidth;
            FrameHeight = GameMap.row * gameEngine.unitHeight;
        }

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Init()
        {
            gameEngine.Init();
        }



        /// <summary>
        /// 起動処理
        /// </summary>
        public void Run()
        {
            Init();

            //マルチスレッド処理
            task = Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (active)
                {
                    //キャラクタの移動処理
                    foreach (var character in gameEngine.characters)
                    {
                        if (character.type >= Character.PLAYER) character.Move();
                    }
                    //ビットマップ画面の作成処理
                    IsBuilding = true;
                    ClearScreen(BackgroundColor);
                    foreach (var character in gameEngine.characters)
                    {
                        if (character.type != Character.ROAD) DrawCharacter(character);
                    }
                    IsBuilding = false;
                    //再描画要求
                    InvalidateScreen();
                    //速度調整
                    while (sw.ElapsedMilliseconds < 10) ;
                    sw.Restart();
                }
                DisposeScreen();
            });
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void End()
        {
            //スレッド終了指令
            active = false;
            //スレッド終了待機
            task.Wait();
        }

        public void SetKeyCode(int keyCode)
        {
            gameEngine.keyCode = keyCode;
        }

        #endregion

        #region 抽象メソッド - テンプレート

        public abstract void ClearScreen(Color backgroundColor);
        public abstract void DrawCharacter(Character character);
        public abstract void InvalidateScreen();
        public abstract void DisposeScreen();

        #endregion

    }
}