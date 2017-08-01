using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherUWP.Models;
using WeatherUWP.Services;

namespace WeatherUWP.Commands
{
    class UpdateCommand : ICommand
    {
        private readonly ICityService _cityService;

        private readonly Func<int, City> _loadChangedCity;

        private readonly Action _callback;

        public UpdateCommand(ICityService cityService, Func<int, City> loadChangedCity, Action callback)
        {
            _cityService = cityService;
            _loadChangedCity = loadChangedCity;
            _callback = callback;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                int id = Int32.Parse(parameter.ToString());
                var updateCity = _loadChangedCity(id);
                try
                {
                    await _cityService.UpdateCityAsync(updateCity);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _callback();
                }
            }   
        }

        public event EventHandler CanExecuteChanged;
    }
}
