using ConferenceMauiDemo.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConferenceMauiDemo.ViewModels;

[INotifyPropertyChanged]
public partial class MainPageViewModel
{
    [RelayCommand]
    private async Task NavigateToSessions()
    {
       await Shell.Current.GoToAsync($"///{nameof(SessionsPage)}");
    }
}
