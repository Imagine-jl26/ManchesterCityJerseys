namespace ManchesterCityJerseys.Core.Interfaces
{
    public interface IDeviceInfoService
    {
        string GetDeviceModel();
        string GetManufacturer();
        string GetOSVersion();
        string GetPlatform();
        string GetAppVersion();
        string GetDeviceName();
        string GetScreenResolution();
    }
}
