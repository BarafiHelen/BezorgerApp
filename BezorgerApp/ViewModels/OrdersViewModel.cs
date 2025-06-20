using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BezorgerApp.Models;
using BezorgerApp.Services;

namespace BezorgerApp.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Order> Orders { get; set; } = new();
        private readonly ApiService _apiService;

        public OrdersViewModel(ApiService apiService)
        {
            _apiService = apiService;
            LoadOrders();
        }

        private async void LoadOrders()
        {
            try
            {
                var result = await _apiService.GetOrdersAsync();
                Console.WriteLine($"Aantal bestellingen opgehaald: {result.Count}");
                Orders.Clear();
                foreach (var order in result)
                    Orders.Add(order);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Fout", $"Bestellingen ophalen mislukt: {ex.Message}", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
