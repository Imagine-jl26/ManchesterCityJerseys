using ManchesterCityJerseys.ViewModels;

namespace ManchesterCityJerseysApp.Views;

public partial class JerseyListPage : ContentPage
{
    private readonly JerseyListViewModel _viewModel;

    public JerseyListPage(JerseyListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel.LoadJerseysCommand.CanExecute(null))
        {
            _viewModel.LoadJerseysCommand.Execute(null);
        }
    }
}
