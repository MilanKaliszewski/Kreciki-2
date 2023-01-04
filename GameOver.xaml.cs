using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace kreciki;

public partial class GameOver : ContentPage
{
	public GameOver(int wynik, int reason, string time)
	{
		InitializeComponent();
        this.wynik.Text= "Twój wynik wyniós³: "+wynik.ToString()+" punktów.";
        this.czas.Text = "Czas gry: "+time;
        if (reason == 1)
        {
            this.powod.Text = "Przegra³eœ poniewa¿: uzyska³eœ mniej ni¿ -10 punktów :(";
        }else if(reason == 2)
        {
            this.powod.Text = "Przegra³eœ poniewa¿: nie naciskasz w kreciki :(";
        }

        //zapisWyniku(wynik, reason, time);
	}

    //Reasons:
    // 1 - (-10punktów)
    // 2 - klikanie nie tam gdzie trzeba


/*    async void zapisWyniku(int wynik, int reason, string time)
    {
        string name = await DisplayPromptAsync("Zapisz wynik", "What's your name?");
        if (name == null) { return; } else
        {
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "wyniki.txt");
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync($"{name} | {wynik} | {reason} | {time}\n");
        }
    }
*/

    private void nowagra_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new GamePage());
    }

    private void scoreboard_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ScoreboardPage());
    }
}