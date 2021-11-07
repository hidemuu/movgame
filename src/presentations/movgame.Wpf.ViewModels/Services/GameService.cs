using movgame.Models.Characters;
using movgame.Repository;
using movgame.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace movgame.Wpf.ViewModels.Services
{
    public class GameService : GameServiceBase
    {

        public GameService(ILandMarkRepository landMarkRepository) : base(landMarkRepository)
        {
        }

        protected override void ClearScreen()
        {
            ScreenGraphics.Clear(Color.White);
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
            //throw new NotImplementedException();
        }
    }
}
