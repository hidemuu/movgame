using movgame.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movgame.WinForm.ViewModels
{
    /// <summary>
    /// ゲームクラス
    /// </summary>
    public class Game
    {

        #region フィールド

        /// <summary>
        /// 画面幅
        /// </summary>
        int frameWidth;
        /// <summary>
        /// 画面高さ
        /// </summary>
        int frameHeight;
        /// <summary>
        /// ゲームスレッド
        /// </summary>
        Task task;
        /// <summary>
        /// スレッド継続フラグ
        /// </summary>
        bool active = true;
        /// <summary>
        /// ビットマップ画面
        /// </summary>
        Bitmap screenBmp;
        /// <summary>
        /// ビットマップ画面作成中フラグ
        /// </summary>
        bool building = false;
        /// <summary>
        /// フォームインスタンス
        /// </summary>
        Form form;

        public GameEngine gameEngine;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Game(Form form)
        {
            this.form = form;
            gameEngine = new GameEngine();
            frameWidth = GameMap.col * gameEngine.unitWidth;
            frameHeight = GameMap.row * gameEngine.unitHeight;
            this.form.ClientSize = new Size(frameWidth, frameHeight);
            screenBmp = new Bitmap(frameWidth, frameHeight);
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
            var g = Graphics.FromImage(screenBmp);

            //マルチスレッド処理
            task = Task.Run(() => 
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                while (active)
                {
                    //キャラクタの移動処理
                    foreach (var c in gameEngine.characters)
                    {
                        if (c.type >= Character.PLAYER) c.Move();
                    }
                    //ビットマップ画面の作成処理
                    building = true;
                    g.Clear(this.form.BackColor);
                    foreach(var c in gameEngine.characters)
                    {
                        if (c.type != Character.ROAD) c.Draw(g);
                    }
                    building = false;
                    //再描画要求
                    this.form.Invalidate();
                    //速度調整
                    while (sw.ElapsedMilliseconds < 10) ;
                    sw.Restart();
                }
                g.Dispose();
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

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if (building) return;
            g.DrawImage(screenBmp, 0, 0);
        }

        
        

        #endregion
    }
}
