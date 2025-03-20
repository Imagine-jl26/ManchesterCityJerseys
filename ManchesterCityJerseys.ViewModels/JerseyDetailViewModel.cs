using CommunityToolkit.Mvvm.ComponentModel;
using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.Core.Models;

namespace ManchesterCityJerseys.ViewModels
{
    public partial class JerseyDetailViewModel(IJerseyService jerseyService) : BaseViewModel
    {
        private readonly IJerseyService _jerseyService = jerseyService ?? throw new ArgumentNullException(nameof(jerseyService));

        [ObservableProperty]
        private Jersey selectedJersey;

        public async Task InitializeAsync(int jerseyId)
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;
                ClearErrors();

                var jersey = await _jerseyService.GetJerseyByIdAsync(jerseyId);

                if (jersey != null)
                {
                    SelectedJersey = jersey;
                    return;
                }

                AddError("Jersey not found.");
            }
            catch (Exception ex)
            {
                AddError($"Failed to load jersey: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }      
        }
    }
}
