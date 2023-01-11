namespace CalcApp;

public partial class App : Application
{
    public static Window Window { get; private set; }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);
        Window = window;
        return window;
    }
}
