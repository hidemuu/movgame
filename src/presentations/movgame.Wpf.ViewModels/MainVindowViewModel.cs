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
        protected ObservableCollection<CanvasImage> Items { get; set; }
        public ReadOnlyReactiveCollection<CanvasImage> Models;
        public IRegionManager RegionManager { get; }

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
            this.bitmap = new Bitmap(400, 400);
            this.graphics = Graphics.FromImage(bitmap);
            IntPtr hbitmap = bitmap.GetHbitmap();
            var image = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Items = new ObservableCollection<CanvasImage>();
            Items.Add(new CanvasImage() { ImageSource = image });
            Models = Items.ToReadOnlyReactiveCollection(x => x);
            
            gameService.Run();

            // 定期更新スレッド
            var timer = new ReactiveTimer(TimeSpan.FromMilliseconds(0.1), new SynchronizationContextScheduler(SynchronizationContext.Current));
            timer.Subscribe(_ =>
            {

            });
            timer.AddTo(disposables);
            timer.Start();

        }

    }
}
