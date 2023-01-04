namespace kreciki;

public partial class HowToPlayPage : ContentPage
{
	public HowToPlayPage()
	{
		InitializeComponent();
	}

    private void goBack_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}