using ConferenceMauiDemo.ViewModels;

namespace ConferenceMauiDemo.Views;

public partial class SessionDetailPage : ContentPage
{
    public SessionDetailPage(SessionDetailPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}