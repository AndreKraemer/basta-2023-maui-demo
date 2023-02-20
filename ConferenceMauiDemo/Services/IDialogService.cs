namespace ConferenceMauiDemo.Services
{
    public interface IDialogService
    {
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);

        Task<bool> DisplayConfirm(string title, string message, string accept, string cancel);
    }
}
