namespace ManchesterCityJerseysApp.Views;

public partial class DeviceInfoPage : ContentPage
{
    private readonly DeviceInfoViewModel _viewModel;

    public DeviceInfoPage(DeviceInfoViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel.LoadDeviceInfo();
    }
}
