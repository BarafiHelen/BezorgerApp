using BezorgerApp.ViewModels;

namespace BezorgerApp.Views;

public partial class OrdersPage : ContentPage
{
	public OrdersPage()
	{
		InitializeComponent();
		BindingContext = new OrdersViewModel();
	}
}