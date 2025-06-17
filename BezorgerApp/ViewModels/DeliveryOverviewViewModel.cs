using BezorgerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BezorgerApp.ViewModels
{
    public class DeliveryOverviewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Order> DeliveredOrders { get; set; } = new();
        public ObservableCollection<Order> FailedOrders { get; set; } = new();

        public DeliveryOverviewViewModel(List<Order> allOrders)
        {
            var today = DateTime.Today;
            foreach (var o in allOrders)
            {
                if (o.DeliveredAt?.Date == today && o.DeliverySucceeded)
                    DeliveredOrders.Add(o);
                else if (o.Status == "Niet afgeleverd")
                    FailedOrders.Add(o);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}
