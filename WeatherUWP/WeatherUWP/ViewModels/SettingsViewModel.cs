using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using WeatherUWP.Commands;
using WeatherUWP.Messages;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;

        private readonly ICityService _cityService;

        public string Error { get; set; }

        public ICommand GoBack { get; set; }

        public ICommand DeleteCity { get; set; }

        public ICommand UpdateCity { get; set; }

        public ICommand AddCity { get; set; }

        public List<City> Cities { get; set; }

        public string NewCity { get; set; }

        public SettingsViewModel(INavigationService navigation, ICityService cityService)
        {
            _navigation = navigation;
            _cityService = cityService;

            Title = "Settings";

            GoBack = new RelayCommand(() => _navigation.GoBack());
            AddCity = new RelayCommand(AddNewCity);
            DeleteCity = new DeleteCommand(_cityService, InitCities);

            InitCities();

            UpdateCity = new UpdateCommand(_cityService, LoadCity, InitCities);
        }

        private City LoadCity(int id)
        {
            return Cities.FirstOrDefault(c => c.Id == id);
        }

        private async void InitCities()
        {
            Cities = (await _cityService.GetDefaultCitiesAsync()).ToList();
            NewCity = string.Empty;
            MessengerInstance.Send(new CitiesRefreshMessage());
            NotificateView();
        }

        private void NotificateView()
        {
            RaisePropertyChanged(() => Cities);
            RaisePropertyChanged(() => NewCity);
            RaisePropertyChanged(() => Error);
        }

        private async void AddNewCity()
        {
            if (string.IsNullOrEmpty(NewCity))
            {
                Error = "City name cannot be empty";
                NotificateView();
            }
            else
            {
                try
                {
                    await _cityService.AddCityAsync(new City {Name = NewCity});
                    Error = string.Empty;
                }
                catch (Exception ex)
                {
                    Error = "Invalid city";
                }
                finally
                {
                    InitCities();
                    MessengerInstance.Send(new CitiesRefreshMessage());
                }    
            }
        }
    }
}
