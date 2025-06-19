using BezorgerApp.Models;
using BezorgerApp.ViewModels;

namespace BezorgerApp.Views;

public partial class DeliverySummaryPage : ContentPage
{
	public DeliverySummaryPage(List<Order> orders)
	{
		InitializeComponent();
        BindingContext = new DeliveryOverviewViewModel(orders);
    }
}