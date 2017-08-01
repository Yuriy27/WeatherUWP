using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WeatherUWP.Messages;
using WeatherUWP.Services;
using WeatherUWP.Models.OpenWeatherModels;
using City = WeatherUWP.Models.City;

namespace WeatherUWP.ViewModels
{
    class ForecastViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;

        private readonly IForecastService _forecastService;

        private readonly ICityService _cityService;

        public ICommand GoBack { get; set; }

        public ICommand ForecastCommand { get; set; }

        public string City { get; set; }

        public string SelectedCity { get; set; }

        public List<City> Cities { get; set; }

        public ObservableCollection<string> CityNames { get; set; }

        public int Days { get; set; }

        public string Error { get; set; }

        public ForecastObject WeatherForecast { get; set; }

        public ForecastViewModel(INavigationService navigation, IForecastService forecastService, ICityService cityService)
        {
            _navigation = navigation;
            _forecastService = forecastService;
            _cityService = cityService;

            MessengerInstance.Register<CitiesRefreshMessage>(this, CitiesRefresh);

            InitValues();
        }

        private async void InitValues()
        {
            Title = "Weather forecast";
            Days = 1;

            GoBack = new RelayCommand(() => _navigation.GoBack());
            ForecastCommand = new RelayCommand(GetForecast);

            LoadCities();
        }

        private async void LoadCities()
        {
            Cities = (await _cityService.GetDefaultCitiesAsync()).ToList();
            CityNames = new ObservableCollection<string>(Cities.Select(c => c.Name).ToList());
            SelectedCity = CityNames.Count == 0 ? null : CityNames[0];
            NotificateView();
        }

        private void CitiesRefresh(CitiesRefreshMessage message)
        {
            LoadCities();
        }

        private async void GetForecast()
        {
            var searchCity = string.IsNullOrEmpty(City) ? SelectedCity : City;
            try
            {
                WeatherForecast = await _forecastService.GetForecastAsync(searchCity, Days);
                Error = null;
            }
            catch (Exception ex)
            {
                WeatherForecast = null;
                Error = $"Our application doesn't provide forecast for {searchCity}";
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
            RaisePropertyChanged(() => CityNames);
            RaisePropertyChanged(() => SelectedCity);
        }
    }
}
