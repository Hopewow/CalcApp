using CalcApp.ViewModel;
using CommunityToolkit.Mvvm.Input;

namespace CalcApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
	{
        var window = App.Window;
        window.Created += (s, e) =>
        {
            BindingContext = vm;
            InitializeComponent();
        };
        window.Stopped += (s, e) =>
        {
            DisplayAlert("Message", "Application has been Stopped", "OK");
        };
        window.Deactivated += (s, e) =>
        {
            DisplayAlert("Message", "Application has been Deactivated", "OK");

        };
        window.Resumed += (s, e) =>
        {
            DisplayAlert("Message", "Application has been Resumed", "OK");
        };
        window.Destroying += (s, e) =>
        {
            DisplayAlert("Message", "Application has been Destroyed", "OK");
        };
	}
}

