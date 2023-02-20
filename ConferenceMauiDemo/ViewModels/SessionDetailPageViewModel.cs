using ConferenceMauiDemo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConferenceMauiDemo.ViewModels;

[INotifyPropertyChanged]
[QueryProperty(nameof(Session), nameof(Session))]
public partial class SessionDetailPageViewModel
{

    [ObservableProperty]
    private Session _session;

    [RelayCommand]
    private void OpenTwitter()
    {
        Browser.OpenAsync(Session.Speaker.Twitter);
    }

}
