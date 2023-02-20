using ConferenceMauiDemo.Services;
namespace ConferenceMauiDemo.Droid;
public class AndroidDeviceInformation : IDeviceInformation
{
    public  string GetName()
    {
        return Android.OS.Build.Device;
    }
}
