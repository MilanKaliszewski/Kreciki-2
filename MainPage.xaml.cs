using System.Diagnostics;

namespace kreciki;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        InitializeComponent();

    }

    private void startGame_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new GamePage());
    }

    private void scoreboard_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ScoreboardPage());
    }

    private void howtoplay_Clicked(object sender, EventArgs e) 
    {
        Navigation.PushModalAsync(new HowToPlayPage());
    }

    private async void exit_Clicked(object sender, EventArgs e) 
    {
        bool answer = await DisplayAlert("Zamknąć aplikację?", "Czy chcesz zakończyć działanie programu?", "Tak", "Nie");
        if(answer)
        {
            Application.Current.Quit();
        }
        else
        {
            return;
        }
    }
}

