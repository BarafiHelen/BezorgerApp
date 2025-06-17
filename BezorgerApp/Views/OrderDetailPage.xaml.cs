using BezorgerApp.Models;
using BezorgerApp.ViewModels;

namespace BezorgerApp.Views;

public partial class OrderDetailPage : ContentPage
{
	public OrderDetailPage(Order selectedOrder)
	{
		InitializeComponent();
        BindingContext = new OrderDetailViewModel(selectedOrder);
    }
}