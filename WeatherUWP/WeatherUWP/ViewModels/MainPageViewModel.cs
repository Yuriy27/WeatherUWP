using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WeatherUWP.Views;

namespace WeatherUWP.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private INavigationService _navigation;

        public ICommand GoToForecast { get; set; }
        public ICommand GoToHistory { get; set; }
        public ICommand GoToSettings { get; set; }

        public MainPageViewModel(INavigationService navigation)
        {
            _navigation = navigation;

            Title = "WeatherApp";

            GoToForecast = new RelayCommand(() => _navigation.NavigateTo(nameof(ForecastViewModel)));
            GoToHistory = new RelayCommand(() => _navigation.NavigateTo(nameof(HistoryViewModel)));
            GoToSettings= new RelayCommand(() => _navigation.NavigateTo(nameof(SettingsViewModel)));
        }
    }
}
