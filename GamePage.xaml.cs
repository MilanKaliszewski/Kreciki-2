using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace kreciki;

public partial class GamePage : ContentPage
{

    int count = 0;
    int reason;
    bool inGame = true;
    string time = "";
    bool firstRun = true;
    ImageButton ib;

    public GamePage()
	{
		InitializeComponent();
        reason= 0;
        count= 0;
        firstRun= false;
        inGame= true;
        time = "";
        startGame();
        startTimer();
	}


    private int podajWiersz()
    {
        Random rnd = new Random();
        int rand1;
        rand1 = rnd.Next(6);
        return rand1;
    }


    private int podajKolumne()
    {
        Random rnd = new Random();
        int rand1;
        rand1 = rnd.Next(7);
        return rand1;
    }

    private void startGame()
    {
        Grid grid = this.grid;

        if (count < -10 || !inGame)
        {
            Navigation.PushModalAsync(new GameOver(count, reason, time));

        }

        if (count <= -10)
        {
            inGame = false;
            reason = 1;
        }


        ib = new ImageButton
        {
            Source = "kret.png",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),
        };

        grid.Add(ib, podajKolumne(), podajWiersz());

        ib.Clicked += (sender, e) =>
        {
            count++;
            this.licznik.Text = $"Aktualny wynik: {count}";
            grid.Remove(ib);
            first = false;
            temp = 0;
            startGame();
        };


    }


    void przegrana()
    {
        inGame = false;
        reason = 2;
        first = false;
        temp = 0;
        Navigation.PushModalAsync(new GameOver(count, reason, time));
    }


    void startTimer()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        IDispatcherTimer timer;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(0);
        timer.Tick += (s, e) =>
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            this.licznikCzas.Text = "Aktualny czas: " + elapsedTime;
            time = elapsedTime;
        };
        timer.Start();
    }



    bool first = false;
    int temp = 0;
    void minus(object sender, EventArgs e)
    {
        if (!first)
        {
            first = true;
            count--;
            this.licznik.Text = $"Aktualny wynik: {count}";
            grid.Remove(ib);
            grid.GestureRecognizers.Clear();
            temp++;
            startGame();

        }
        else if (first && temp > 2)
        {
            count--;
            this.licznik.Text = $"Aktualny wynik: {count}";
            grid.Remove(ib);
            grid.GestureRecognizers.Clear();
            temp++;
            przegrana();
        }
        else
        {
            count--;
            this.licznik.Text = $"Aktualny wynik: {count}";
            grid.Remove(ib);
            grid.GestureRecognizers.Clear();
            temp++;
            startGame();
        }

    }
}