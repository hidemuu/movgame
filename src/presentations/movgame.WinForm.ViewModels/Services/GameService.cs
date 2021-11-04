using movgame.Models.Characters;
using movgame.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace movgame.WinForm.ViewModels.Services
{
    public class GameService : GameServiceBase
    {
        /// <summary>
        /// ビットマップ画面
        /// </summary>
        Bitmap screenBmp;

        /// <summary>
        /// グラフィック
        /// </summary>
        Graphics graphics;

        /// <summary>
        /// フォームインスタンス
        /// </summary>
        Form form;

        public override Color BackgroundColor { get; set; }

        public GameService(Form form) : base()
        {
            this.form = form;
            screenBmp = new Bitmap(FrameWidth, FrameHeight);
            graphics = Graphics.FromImage(screenBmp);
            this.form.ClientSize = new Size(FrameWidth, FrameHeight);
            BackgroundColor = this.form.BackColor;
        }

        public override void ClearScreen(Color backgroundColor)
        {
            graphics.Clear(backgroundColor);
        }

        public override void DisposeScreen()
        {
            graphics.Dispose();
        }

        public void Draw(Graphics g)
        {
            if (IsBuilding) return;
            g.DrawImage(screenBmp, 0, 0);
        }

        public override void DrawCharacter(Character character)
        {
            character.Draw(graphics);
        }

        public override void InvalidateScreen()
        {
            this.form.Invalidate();
        }
    }
}
