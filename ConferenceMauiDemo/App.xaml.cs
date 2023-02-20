namespace ConferenceMauiDemo;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        // Fensterposition setzen
        window.X = 300;
        window.Y = 100;

        // Größe des Fensters definieren
        window.Width = 401;
        window.Height = 800;
        Task.Run(async () =>
        {
            await Task.Delay(3500);
            window.Width = 400;
        });
        return window;
    }
}

