using ConferenceMauiDemo.Services;

namespace ConferenceMauiDemo.Views;

public partial class DependencyInjectionDemoPage : ContentPage
{
    public DependencyInjectionDemoPage(IDeviceInformation deviceInfo)
    {
        InitializeComponent();
        DeviceInfoLabel.Text = deviceInfo.GetName();
    }
}