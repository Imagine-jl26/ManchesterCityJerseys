using ManchesterCityJerseys.Core.Models;

namespace ManchesterCityJerseys.Core.Interfaces
{
    public interface IJerseyService
    {
        Task<List<Jersey>> GetJerseysAsync();
        Task<Jersey?> GetJerseyByIdAsync(int id);
    }
}
