using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BezorgerApp.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        private Location _currentLocation;
        public Location CurrentLocation
        {
            get => _currentLocation;
            set { _currentLocation = value; OnPropertyChanged(); }
        }

        public MapViewModel()
        {
            // Later GPS ophalen en invullen
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
