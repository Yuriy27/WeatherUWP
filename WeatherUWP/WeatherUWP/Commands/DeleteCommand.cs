using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherUWP.Services;

namespace WeatherUWP.Commands
{
    class DeleteCommand : ICommand
    {
        private readonly ICityService _cityService;

        private readonly Action _callback;

        public DeleteCommand(ICityService cityService, Action callback)
        {
            _cityService = cityService;
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
                int cityId = Int32.Parse(parameter.ToString());
                await _cityService.DeleteCityAsync(cityId);
                _callback();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
