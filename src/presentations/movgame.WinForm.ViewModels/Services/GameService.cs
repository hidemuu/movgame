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
        /// フォームインスタンス
        /// </summary>
        Form form;

        public GameService(Form form) : base()
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
