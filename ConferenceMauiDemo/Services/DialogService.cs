namespace ConferenceMauiDemo.Services
{
    public class DialogService : IDialogService
    {
        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public async Task<bool> DisplayConfirm(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
