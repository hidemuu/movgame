using movgame.Repository;
using movgame.Repository.InMemory;
using movgame.Service;
using movgame.Wpf.ViewModels;
using movgame.Wpf.ViewModels.Dialogs;
using movgame.Wpf.ViewModels.Services;
using movgame.Wpf.Views;
using movgame.Wpf.Views.Dialogs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace movgame.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// シェル生成
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>(); //初期表示ビュー
        }

        /// <summary>
        /// コンテナ登録
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //DIコンテナ GetContainerでUnityのコンテナに直接アクセス可能
            var container = containerRegistry.GetContainer();

            //リポジトリの登録
            containerRegistry.RegisterInstance<ILandMarkRepository>(new InMemoryLandMarkRepository());
            
            //サービスの登録
            containerRegistry.RegisterInstance<IGameService>(Container.Resolve<GameService>());

            //Viewの登録
            containerRegistry.RegisterForNavigation<TitleView>();
            containerRegistry.RegisterForNavigation<GameView>();
            containerRegistry.RegisterForNavigation<ConfigView>();

            //Dialogの登録
            containerRegistry.RegisterDialog<GameOverDialog, GameOverDialogViewModel>();
            containerRegistry.RegisterDialog<StageClearDialog, StageClearDialogViewModel>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }

        /// <summary>
        /// View-ViewModel関連付け
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainVindowViewModel>();
            ViewModelLocationProvider.Register<TitleView, TitleViewModel>();
            ViewModelLocationProvider.Register<GameView, GameViewModel>();
            ViewModelLocationProvider.Register<ConfigView, ConfigViewModel>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

    }
}
