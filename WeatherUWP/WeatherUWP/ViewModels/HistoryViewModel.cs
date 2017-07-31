using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        private INavigationService _navigation;

        private IHistoryService _historyService;

        public ICommand GoBack { get; set; }

        public IEnumerable<History> ForecastsHistory { get; set; }

        public HistoryViewModel(INavigationService navigation, IHistoryService historyService)
        {
            _navigation = navigation;
            _historyService = historyService;

            Title = "Weather History";

            GoBack = new RelayCommand(() => _navigation.GoBack());

            InitValues();
        }

        private async void InitValues()
        {
            ForecastsHistory = await _historyService.GetHistory();
            RaisePropertyChanged(() => ForecastsHistory);
        }
    }
}
