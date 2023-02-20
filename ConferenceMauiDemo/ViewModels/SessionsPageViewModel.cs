using ConferenceMauiDemo.Models;
using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.Views;
using ConferenceMauiDemo.ApplicationWindows;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ConferenceMauiDemo.ViewModels;

[INotifyPropertyChanged]
public partial class SessionsPageViewModel
{
    
    private readonly ObservableCollection<Session> _sessions = new ObservableCollection<Session>();
    private readonly IDataService _dataService;
    private readonly IApplication _application;
    private readonly IDialogService _dialogService;

    public ObservableCollection<Session> Sessions => _sessions;


    public SessionsPageViewModel(IDataService dataService, IApplication application, IDialogService dialogService)
    {
        _dataService = dataService;
        _application = application;
        _dialogService = dialogService;
    }

    public async Task Initialize()
    {
        _sessions.Clear();
        var sessions = await _dataService.GetSessionsAsync();
        foreach (var session in sessions)
        {
            _sessions.Add(session);
        }
    }

    [RelayCommand]
    private async Task NavigateToDetailsPage(Session session)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "Session", session }
            };
        await Shell.Current.GoToAsync(nameof(SessionDetailPage), navigationParameter);
    }

    [RelayCommand]
    private void OpenDetailsPageInNewWindow(Session session)
    {
        //var window = new SessionDetailWindow(session)
        //{
        //    Width = 500,
        //    Height = 650
        //};

        var detailsVM = new SessionDetailPageViewModel
        {
            Session = session
        };

        var sessionPage = new SessionDetailPage(detailsVM);

        var window = new Window(sessionPage);


        _application.OpenWindow(window);
       }

    [RelayCommand]
    private async Task CallSpeaker(Speaker speaker)
    {

        var result = await _dialogService.DisplayActionSheet("Sprecher anrufen", "Abbrechen", null, new[] { "Privat", "Geschäftlich" });
        switch (result)
        {
            case "Privat":
                await CallSpeakerPrivate(speaker);
                break;
            case "Geschäftlich":
                await CallSpeakerBusiness(speaker);
                break;
        }
    }

    [RelayCommand]
    private async Task CallSpeakerBusiness(Speaker speaker)
    {
        if (PhoneDialer.IsSupported)
        {
            PhoneDialer.Open("+49 123 456 789");
        }
        else
        {
            var message = $"Leider unterstützt Ihr Gerät keine Anrufe.";
            var toast = Toast.Make(message, ToastDuration.Long);
            await toast.Show();
        }
    }

    [RelayCommand]
    private async Task CallSpeakerPrivate(Speaker speaker)
    {
        var message = $"{speaker.Name} nimmt private Anrufe leider nur von Freunden und Familienangehörigen entgegen. Bitte versuchen Sie es unter der geschäftlichen Nummer.";
        var toast = Toast.Make(message, ToastDuration.Long);
        await toast.Show();
    }

    [RelayCommand]
    private async Task Favorite(Session session)
    {
        session.Favorite = !session.Favorite;

        var message = session.Favorite ? "Wir freuen uns, dass Ihnen die Session gefällt" :
                                         "Schade, dass Ihnen die Session nicht mehr gefällt";



        var toast = Toast.Make(message, ToastDuration.Long, 28);

        await toast.Show();
    }
}
