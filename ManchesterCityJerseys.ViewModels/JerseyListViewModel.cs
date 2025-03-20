using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.Core.Models;

namespace ManchesterCityJerseys.ViewModels
{
    public partial class JerseyListViewModel : BaseViewModel
    {
        private readonly IJerseyService _jerseyService;
        private readonly IDeviceInfoService _deviceInfoService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<JerseyItemViewModel> Jerseys { get; } = new();

        [ObservableProperty]
        private bool isRefreshing;

        public JerseyListViewModel(IJerseyService jerseyService, IDeviceInfoService deviceInfoService, INavigationService navigationService)
        {
            _jerseyService = jerseyService ?? throw new ArgumentNullException(nameof(jerseyService));
            _deviceInfoService = deviceInfoService ?? throw new ArgumentNullException(nameof(deviceInfoService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            LoadJerseysCommand = new AsyncRelayCommand(LoadJerseysAsync);
            NavigateToDeviceInfoCommand = new AsyncRelayCommand(NavigateToDeviceInfo);
        }

        public IAsyncRelayCommand LoadJerseysCommand { get; }
        public IAsyncRelayCommand NavigateToDeviceInfoCommand { get; }

        private async Task LoadJerseysAsync()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = !IsRefreshing;
                IsRefreshing = true;
                ClearErrors();

                var jerseys = await _jerseyService.GetJerseysAsync();

                Jerseys.Clear();

                if (jerseys == null || !jerseys.Any())
                {
                    AddError("No jerseys available.");
                    return;
                }

                foreach (var jersey in jerseys)
                {
                    Jerseys.Add(new JerseyItemViewModel(jersey, new AsyncRelayCommand(() => OnJerseySelected(jersey))));
                }
            }
            catch (Exception ex)
            {
                AddError($"Failed to load jerseys: {ex.Message}");
            }
            finally
            {
                IsLoading = IsRefreshing = false;
            }
        }

        private async Task NavigateToDeviceInfo()
        {
            await _navigationService.NavigateToAsync("DeviceInfoPage");
        }

        private async Task OnJerseySelected(Jersey? selectedJersey)
        {
            if (selectedJersey == null)
            {
                return;
            }

            await _navigationService.NavigateToAsync($"JerseyDetailPage?selectedJerseyId={selectedJersey.Id}");
        }
    }
}
