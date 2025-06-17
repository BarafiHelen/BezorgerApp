using BezorgerApp.Models;
using BezorgerApp.Services;
using BezorgerApp.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace BezorgerApp.Views;

public partial class OrderDetailPage : ContentPage
{
    public Order SelectedOrder
    {
        get => (BindingContext as OrderDetailViewModel)?.SelectedOrder;
        set
        {
            var apiService = App.Services.GetService<ApiService>();
            BindingContext = new OrderDetailViewModel(value, apiService);
        }
    }

    public OrderDetailPage()
    {
        InitializeComponent();
    }
}