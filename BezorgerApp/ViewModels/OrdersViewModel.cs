using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BezorgerApp.Models;

namespace BezorgerApp.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Order> Orders { get; set; }

        public OrdersViewModel()
        {
            // Dummydata
            Orders = new ObservableCollection<Order>
            {
                new Order
                {
                    Id = 1,
                    CustomerName = "Helen Barafi",
                    Address = "Straat 10, Amsterdam",
                    Status = "Wachtend"
                },
                new Order
                {
                    Id = 2,
                    CustomerName = "Sara Noor",
                    Address = "Laan 25, Utrecht",
                    Status = "Onderweg"
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
