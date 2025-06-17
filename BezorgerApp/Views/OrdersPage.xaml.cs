using BezorgerApp.Models;
using BezorgerApp.ViewModels;

namespace BezorgerApp.Views;

public partial class OrdersPage : ContentPage
{
    public OrdersPage()
    {
        InitializeComponent();
        BindingContext = new OrdersViewModel();
    }
    private async void OnOrderSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedOrder = e.CurrentSelection.FirstOrDefault() as Order;
        if (selectedOrder != null)
        {
            await Shell.Current.GoToAsync(nameof(OrderDetailPage), true, new Dictionary<string, object>
            {
                { "SelectedOrder", selectedOrder }
            });
        }
    }
}