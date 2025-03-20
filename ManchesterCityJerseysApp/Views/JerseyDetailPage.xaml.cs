using ManchesterCityJerseys.ViewModels;

namespace ManchesterCityJerseysApp.Views;

[QueryProperty(nameof(SelectedJerseyId), "selectedJerseyId")]
public partial class JerseyDetailPage : ContentPage
{
    private readonly JerseyDetailViewModel _viewModel;

    public int SelectedJerseyId { get; set; }

    public JerseyDetailPage(JerseyDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync(SelectedJerseyId);
    }
}
