using ConferenceMauiDemo.Services;
namespace ConferenceMauiDemo.iOS;
public class IosDeviceInformation: IDeviceInformation
{
    public string GetName()
    {
        return UIKit.UIDevice.CurrentDevice.Name;
    }
}
