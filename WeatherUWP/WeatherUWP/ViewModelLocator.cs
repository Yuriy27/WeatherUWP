using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using WeatherUWP.Services;
using WeatherUWP.ViewModels;
using WeatherUWP.Views;

namespace WeatherUWP
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(HistoryViewModel), typeof(HistoryPage));
            navigationService.Configure(nameof(SettingsViewModel), typeof(SettingsPage));
            navigationService.Configure(nameof(ForecastViewModel), typeof(ForecastPage));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IForecastService>(() => new ForecastService());
            SimpleIoc.Default.Register<IHistoryService>(() => new HistoryService());

            SimpleIoc.Default.Register<HistoryViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<ForecastViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();

            ServiceLocator.Current.GetInstance<MainPageViewModel>();
        }

        public HistoryViewModel HistoryVmInstance => ServiceLocator.Current.GetInstance<HistoryViewModel>();

        public SettingsViewModel SettingsVmInstance => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ForecastViewModel ForecastVmInstance => ServiceLocator.Current.GetInstance<ForecastViewModel>();

        public MainPageViewModel MainPageVmInstance => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        public static void Cleanup()
        {
            
        }
    }
}
