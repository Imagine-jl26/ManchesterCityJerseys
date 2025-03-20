using ManchesterCityJerseys.Core.Interfaces;

namespace ManchesterCityJerseysApp.Services
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string GetDeviceModel() => DeviceInfo.Model;
        public string GetManufacturer() => DeviceInfo.Manufacturer;
        public string GetOSVersion() => DeviceInfo.VersionString;
        public string GetPlatform() => DeviceInfo.Platform.ToString();
        public string GetAppVersion() => AppInfo.VersionString;

        public string GetDeviceName() => DeviceInfo.Name ?? "Unknown";

        public string GetScreenResolution()
        {
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
            return $"{displayInfo.Width} x {displayInfo.Height} ({displayInfo.Density}x)";
        }
    }
}
