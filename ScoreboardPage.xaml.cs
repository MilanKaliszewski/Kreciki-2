namespace kreciki;

public partial class ScoreboardPage : ContentPage
{
	public ScoreboardPage()
	{
		InitializeComponent();
	}

    private void goBack_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}