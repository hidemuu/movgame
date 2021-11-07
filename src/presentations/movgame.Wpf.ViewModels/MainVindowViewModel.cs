using movgame.Models;
using movgame.Service;
using movgame.Wpf.Models;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace movgame.Wpf.ViewModels
{
    public class MainVindowViewModel : BindableBase
    {
        public CanvasImage Models { get; } = new CanvasImage();
        public IRegionManager RegionManager { get; }

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyDownCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyLeftCommand { get; } = new ReactiveCommand();
        public ReactiveCommand KeyRightCommand { get; } = new ReactiveCommand();

        private readonly IGameService gameService;
        private Bitmap bitmap;
        private Graphics graphics;
        private CompositeDisposable disposables = new CompositeDisposable();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainVindowViewModel(IRegionManager regionManager, IGameService gameService) 
        {
            this.RegionManager = regionManager;
            this.gameService = gameService;

            // 画像作成
            
            this.bitmap = new Bitmap(600, 600);
            this.graphics = Graphics.FromImage(bitmap);
            
            gameService.Run();

            LoadedCommand.Subscribe(() => { });
            KeyUpCommand.Subscribe(() => KeyUp());
            KeyDownCommand.Subscribe(() => KeyDown());
            KeyLeftCommand.Subscribe(() => KeyLeft());
            KeyRightCommand.Subscribe(() => KeyRight());

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(0.1), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {
                gameService.Draw(graphics);
                var hbitmap = bitmap.GetHbitmap();
                Models.ImageSource.Value = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(hbitmap);
            });
            timer.AddTo(disposables);
            timer.Start();
        }

        private void KeyUp()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_UP);
        }

        private void KeyDown()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_DOWN);
        }

        private void KeyLeft()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_LEFT);
        }

        private void KeyRight()
        {
            gameService.SetKeyCode(GameEngine.KEY_CODE_RIGHT);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject); // gdi32.dllのDeleteObjectメソッドの使用を宣言する。
    }
}
