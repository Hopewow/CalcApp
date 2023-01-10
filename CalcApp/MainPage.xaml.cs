using CalcApp.ViewModel;
using CommunityToolkit.Mvvm.Input;

namespace CalcApp;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

