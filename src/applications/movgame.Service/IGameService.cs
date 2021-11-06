using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Service
{
    public interface IGameService
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Initialize();
        /// <summary>
        /// 起動処理
        /// </summary>
        void Run();
        /// <summary>
        /// 終了処理
        /// </summary>
        void End();
        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode">キーコード</param>
        void SetKeyCode(int keyCode);
        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="g"></param>
        void Draw(Graphics g);
    }
}
