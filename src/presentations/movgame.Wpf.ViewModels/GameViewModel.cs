using movgame.Models;
using movgame.Service;
using movgame.Wpf.Models;
using movgame.Wpf.Views;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace movgame.Wpf.ViewModels
{
    public class GameViewModel : BindableBase
    {
        public GameModel Models { get; } = new GameModel();
        private IRegionManager regionManager { get; }
        private readonly IDialogService dialogService;

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();
        public ReactiveTimer Timer { get; } = new ReactiveTimer(TimeSpan.FromMilliseconds(10), new SynchronizationContextScheduler(SynchronizationContext.Current));

        private readonly IGameService gameService;
        private Bitmap bitmap;
        private Graphics graphics;
        private CompositeDisposable disposables = new CompositeDisposable();

        public GameViewModel(IRegionManager regionManager, IDialogService dialogService, IGameService gameService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            this.gameService = gameService;

            // 画像作成
            this.bitmap = new Bitmap(600, 600);
            this.graphics = Graphics.FromImage(bitmap);

            LoadedCommand.Subscribe(() => OnLoadedCommand());
            
            // 定期更新スレッド
            Timer.Subscribe(_ => OnTimer());
            Timer.AddTo(disposables);
        }

        private void OnLoadedCommand()
        {
            gameService.Run();
            Timer.Start();
        }

        private void OnTimer()
        {
            gameService.Draw(graphics);
            var hbitmap = bitmap.GetHbitmap();
            Models.ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Models.Life.Value = gameService.GetLife();
            DeleteObject(hbitmap);
            Models.Score.Value = gameService.Score;
            if (gameService.IsGameOver)
            {
                dialogService.ShowDialog("GameOverDialog", new DialogParameters($"message={"ゲームオーバー!"}"), result =>
                {
                    if (result.Result == ButtonResult.Yes)
                    {
                        regionManager.RequestNavigate("MainRegion", nameof(TitleView));
                        gameService.End();
                        Timer.Stop();
                    }
                });
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject); // gdi32.dllのDeleteObjectメソッドの使用を宣言する。

    }
}
