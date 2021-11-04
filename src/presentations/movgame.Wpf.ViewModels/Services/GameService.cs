using movgame.Models.Characters;
using movgame.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Wpf.ViewModels.Services
{
    public class GameService : GameServiceBase
    {
        /// <summary>
        /// ビットマップ画面
        /// </summary>
        Bitmap screenBmp;

        Graphics graphics;

        public override Color BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GameService() : base()
        {
            screenBmp = new Bitmap(FrameWidth, FrameHeight);
            graphics = Graphics.FromImage(screenBmp);
        }

        public override void ClearScreen(Color backgroundColor)
        {
            graphics.Clear(backgroundColor);
        }

        public override void DisposeScreen()
        {
            graphics.Dispose();
        }

        public void Draw()
        {
            if (IsBuilding) return;
            graphics.DrawImage(screenBmp, 0, 0);
        }

        public override void DrawCharacter(Character character)
        {
            character.Draw(graphics);
        }

        public override void InvalidateScreen()
        {
            throw new NotImplementedException();
        }
    }
}
