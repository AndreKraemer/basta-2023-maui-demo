using ConferenceMauiDemo.ViewModels;

namespace ConferenceMauiDemo.Views;

public partial class MainPage : ContentPage
{


	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}


}

