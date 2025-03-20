using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ManchesterCityJerseys.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        private bool isLoading;

        public ObservableCollection<string> Errors { get; } = new ObservableCollection<string>();

        protected void AddError(string errorMessage)
        {
            if (!Errors.Contains(errorMessage))
            {
                Errors.Add(errorMessage);
            }
        }

        protected void ClearErrors()
        {
            Errors.Clear();
        }
    }
}
