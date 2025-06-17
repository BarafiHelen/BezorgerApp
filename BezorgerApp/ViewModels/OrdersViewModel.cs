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
        private readonly ApiService _apiService = new();

        public OrdersViewModel()
        {
            LoadOrders();
        }

        private async void LoadOrders()
        {
            var result = await _apiService.GetOrdersAsync();
            Orders.Clear();
            foreach (var order in result)
                Orders.Add(order);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
