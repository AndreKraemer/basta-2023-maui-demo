using ConferenceMauiDemo.Services;
namespace ConferenceMauiDemo.MacCatalyst;

public class MacCatalystDeviceInformation : IDeviceInformation
{
    public string GetName()
    {
        return UIKit.UIDevice.CurrentDevice.Name;
    }
}
