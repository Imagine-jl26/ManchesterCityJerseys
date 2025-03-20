using CommunityToolkit.Mvvm.ComponentModel;
using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.ViewModels;

public partial class DeviceInfoViewModel(IDeviceInfoService deviceInfoService) : BaseViewModel
{
    private readonly IDeviceInfoService _deviceInfoService = deviceInfoService ?? throw new ArgumentNullException(nameof(deviceInfoService));

    [ObservableProperty]
    private string deviceModel;

    [ObservableProperty]
    private string manufacturer;

    [ObservableProperty]
    private string osVersion;

    [ObservableProperty]
    private string platform;

    [ObservableProperty]
    private string appVersion;

    [ObservableProperty]
    private string deviceName;

    [ObservableProperty]
    private string screenResolution;

    public void LoadDeviceInfo()
    {
        DeviceModel = _deviceInfoService.GetDeviceModel();
        Manufacturer = _deviceInfoService.GetManufacturer();
        OsVersion = _deviceInfoService.GetOSVersion();
        Platform = _deviceInfoService.GetPlatform();
        AppVersion = _deviceInfoService.GetAppVersion();
        DeviceName = _deviceInfoService.GetDeviceName();
        ScreenResolution = _deviceInfoService.GetScreenResolution();
    }
}
