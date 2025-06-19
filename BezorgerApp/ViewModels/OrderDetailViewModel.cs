using BezorgerApp.Models;
using BezorgerApp.Services;
using Microsoft.Maui.ApplicationModel; // Voor Geolocation
using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiLocation = Microsoft.Maui.Devices.Sensors.Location;


namespace BezorgerApp.ViewModels
{
    public class OrderDetailViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; OnPropertyChanged(); }
        }

        public ICommand SaveStatusCommand { get; }
        public ICommand AddPhotoCommand { get; }
        public ICommand AddGpsCommand { get; }
        public ICommand NextDeliveryCommand { get; }

        public OrderDetailViewModel(Order order, ApiService apiService)
        {
            _apiService = apiService;
            SelectedOrder = order;

            SaveStatusCommand = new Command(async () => await SaveStatus());
            AddPhotoCommand = new Command(AddPhoto);
            AddGpsCommand = new Command(async () => await AddGps());
            NextDeliveryCommand = new Command(NextDelivery);
        }

        public async Task SaveStatus()
        {
            if (SelectedOrder != null)
            {
                var success = await _apiService.UpdateOrderAsync(SelectedOrder);
                if (success)
                    await Shell.Current.DisplayAlert("Success", "Status bijgewerkt", "OK");
                else
                    await Shell.Current.DisplayAlert("Fout", "Bijwerken mislukt", "OK");
            }
        }

        public async Task AddGps()
        {
            try
            {
                MauiLocation location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    var loc = new BezorgerApp.Models.Location
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        Timestamp = DateTime.UtcNow
                    };

                    await _apiService.UploadLocationAsync(SelectedOrder.Id, loc);
                    await Shell.Current.DisplayAlert("Locatie", "Locatie toegevoegd", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Fout", $"Kan locatie niet ophalen: {ex.Message}", "OK");
            }
        }

        private void AddPhoto()
        {
            Shell.Current.DisplayAlert("Foto", "Foto-functie nog niet geïmplementeerd", "OK");
        }

        private void NextDelivery()
        {
            Shell.Current.DisplayAlert("Volgende", "Volgende levering nog niet geïmplementeerd", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}