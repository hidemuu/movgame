using movgame.Models.Characters;
using movgame.Repository;
using movgame.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace movgame.WinForm.ViewModels.Services
{
    /// <summary>
    /// ゲームサービス
    /// </summary>
    public class GameService : GameServiceBase
    {
       
        /// <summary>
        /// フォームインスタンス
        /// </summary>
        private Form form;

        public GameService(Form form, ILandMarkRepository landMarkRepository) : base(landMarkRepository)
        {
            this.form = form;
            this.form.ClientSize = new Size(FrameWidth, FrameHeight);
        }

        protected override void ClearScreen()
        {
            ScreenGraphics.Clear(this.form.BackColor);
        }

        protected override void DisposeScreen()
        {
            ScreenGraphics.Dispose();
        }

        protected override void DrawCharacter(CharacterBase character)
        {
            character.Draw(ScreenGraphics);
        }

        protected override void InvalidateScreen()
        {
            this.form.Invalidate();
        }
    }
}
