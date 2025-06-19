namespace BezorgerApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void OnStartClicked(object sender, EventArgs e)
    {
        // Navigeren naar de orderspagina
        await Shell.Current.GoToAsync("//orders");
    }
}