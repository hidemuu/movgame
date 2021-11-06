using movgame.Service;
using movgame.Wpf.Models;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Threading;

namespace movgame.Wpf.ViewModels
{
    public class MainVindowViewModel : BindableBase
    {
        protected ObservableCollection<CanvasModel> Items { get; set; }
        public ReadOnlyReactiveCollection<CanvasModel> Models;
        public IRegionManager RegionManager { get; }

        private readonly IGameService gameService;
        
        private CompositeDisposable disposables = new CompositeDisposable();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainVindowViewModel(IRegionManager regionManager, IGameService gameService) 
        {
            this.RegionManager = regionManager;
            this.gameService = gameService;

            Items = new ObservableCollection<CanvasModel>();
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
