using BezorgerApp.Models;
using BezorgerApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BezorgerApp.ViewModels
{
    public class OrderDetailViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new();

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

        public OrderDetailViewModel(Order order)
        {
            SelectedOrder = order;

            SaveStatusCommand = new Command(async () => await SaveStatus());
            AddPhotoCommand = new Command(() => AddPhoto());
            AddGpsCommand = new Command(() => AddGps());
            NextDeliveryCommand = new Command(() => NextDelivery());
        }

        private async Task SaveStatus() => await _apiService.UpdateOrderAsync(SelectedOrder);
        private void AddPhoto() { /* Camera-code komt later */ }
        private void AddGps() { /* GPS-locatie opslaan */ }
        private void NextDelivery() { /* Navigatie */ }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
