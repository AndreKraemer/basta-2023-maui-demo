using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.WinUI;


namespace ConferenceMauiDemo.WinUI;
public class WindowsDeviceInformation : IDeviceInformation
{
    public string GetName()
    {
        var deviceInformation = new Windows.Security
            .ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
        return deviceInformation.FriendlyName;
    }
}