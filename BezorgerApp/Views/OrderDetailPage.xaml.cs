using BezorgerApp.Models;
using BezorgerApp.ViewModels;

namespace BezorgerApp.Views;

[QueryProperty(nameof(SelectedOrder), "SelectedOrder")]
public partial class OrderDetailPage : ContentPage
{
    public Order SelectedOrder
    {
        get => (BindingContext as OrderDetailViewModel)?.SelectedOrder;
        set => BindingContext = new OrderDetailViewModel(value);
    }

    public OrderDetailPage()
    {
        InitializeComponent();
    }
}