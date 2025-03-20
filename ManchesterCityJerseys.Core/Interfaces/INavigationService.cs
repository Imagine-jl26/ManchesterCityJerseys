using ManchesterCityJerseys.Core.Models;

namespace ManchesterCityJerseys.Core.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route);
    }
}
