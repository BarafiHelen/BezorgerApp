using BezorgerApp.ViewModels;

namespace BezorgerApp.Views;

public partial class SignaturePage : ContentPage
{
	public SignaturePage()
	{
		InitializeComponent();
        BindingContext = App.Services.GetService<SignatureViewModel>();
    }
}