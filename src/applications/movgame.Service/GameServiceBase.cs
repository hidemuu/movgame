using movgame.Models;
using movgame.Models.Characters;
using movgame.Models.Maps;
using movgame.Repository;
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
    public abstract class GameServiceBase : IGameService
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

        /// <summary>
        /// ランドマークリポジトリ
        /// </summary>
        private ILandMarkRepository landMarkRepository;

        /// <summary>
        /// ビットマップ画面
        /// </summary>
        private Bitmap screenBitmap;

        #endregion

        #region プロパティ

        /// <summary>
        /// 画面幅
        /// </summary>
        protected int FrameWidth { get; private set; }
        /// <summary>
        /// 画面高さ
        /// </summary>
        protected int FrameHeight { get; private set; }
        /// <summary>
        /// ビットマップ画面作成中フラグ
        /// </summary>
        protected bool IsBuilding { get; private set; } = false;
        /// <summary>
        /// グラフィック
        /// </summary>
        protected Graphics ScreenGraphics { get; private set; }

        #endregion

        public GameServiceBase(ILandMarkRepository landMarkRepository)
        {
            this.landMarkRepository = landMarkRepository;
            var maps = landMarkRepository.Get();
            gameEngine = new GameEngine();
            FrameWidth = maps[0].GetCol() * gameEngine.UnitWidth;
            FrameHeight = maps[0].GetRow() * gameEngine.UnitHeight;
            screenBitmap = new Bitmap(FrameWidth, FrameHeight);
            ScreenGraphics = Graphics.FromImage(screenBitmap);
        }

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize()
        {
            gameEngine.Initialize(landMarkRepository.Get()[0]);
        }



        /// <summary>
        /// 起動処理
        /// </summary>
        public void Run()
        {
            Initialize();

            //マルチスレッド処理
            task = Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (active)
                {
                    //キャラクタの移動処理
                    foreach (var character in gameEngine.Characters)
                    {
                        if (character.TypeCode >= CharacterBase.PLAYER) character.Move();
                    }
                    //ビットマップ画面の作成処理
                    IsBuilding = true;
                    ClearScreen();
                    foreach (var character in gameEngine.Characters)
                    {
                        if (character.TypeCode != CharacterBase.ROAD) DrawCharacter(character);
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
            gameEngine.KeyCode = keyCode;
        }

        public void Draw(Graphics graphics)
        {
            if (IsBuilding) return;
            graphics.DrawImage(screenBitmap, 0, 0);
        }

        #endregion

        #region 抽象メソッド - テンプレート

        protected abstract void ClearScreen();
        protected abstract void DrawCharacter(CharacterBase character);
        protected abstract void InvalidateScreen();
        protected abstract void DisposeScreen();

        #endregion

    }
}