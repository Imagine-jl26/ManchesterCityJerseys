using ManchesterCityJerseys.Core.Models;
using System.Windows.Input;

namespace ManchesterCityJerseys.ViewModels
{
    public partial class JerseyItemViewModel : BaseViewModel
    {
        public Jersey Item { get; }

        public ICommand SelectCommand { get; }

        public JerseyItemViewModel(Jersey jersey, ICommand selectedCommand)
        {
            Item = jersey;
            SelectCommand = selectedCommand;
        }
    }
}
