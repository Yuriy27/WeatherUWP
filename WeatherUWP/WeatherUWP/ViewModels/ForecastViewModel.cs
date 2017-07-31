using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WeatherUWP.Models.OpenWeatherModels;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    class ForecastViewModel : BaseViewModel
    {
        private INavigationService _navigation;

        private IForecastService _forecastService;

        public ICommand GoBack { get; set; }

        public ICommand ForecastCommand { get; set; }

        public string City { get; set; }

        public int Days { get; set; }

        public string Error { get; set; }

        public ForecastObject WeatherForecast { get; set; }

        public ForecastViewModel(INavigationService navigation, IForecastService forecastService)
        {
            _navigation = navigation;
            _forecastService = forecastService;

            Title = "Weather forecast";
            Days = 1;

            GoBack = new RelayCommand(() => _navigation.GoBack());
            ForecastCommand = new RelayCommand(GetForecast);
        }

        public async void GetForecast()
        {
            try
            {
                WeatherForecast = await _forecastService.GetForecast(City, Days);
                Error = null;
            }
            catch (Exception ex)
            {
                WeatherForecast = null;
                Error = "The requested city not found";
            }
            finally
            {
                NotificateView();
            }
        }

        private void NotificateView()
        {
            RaisePropertyChanged(() => WeatherForecast);
            RaisePropertyChanged(() => Error);
        }
    }
}
