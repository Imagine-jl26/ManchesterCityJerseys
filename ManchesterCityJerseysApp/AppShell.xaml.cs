using ManchesterCityJerseysApp.Views;

namespace ManchesterCityJerseysApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(JerseyDetailPage), typeof(JerseyDetailPage));
            Routing.RegisterRoute(nameof(DeviceInfoPage), typeof(DeviceInfoPage));
        }
    }
}
