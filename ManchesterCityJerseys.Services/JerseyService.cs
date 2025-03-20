using ManchesterCityJerseys.Core.Interfaces;
using ManchesterCityJerseys.Core.Models;

namespace ManchesterCityJerseys.Services
{
    public class JerseyService : IJerseyService
    {
        private readonly List<Jersey> _jerseys = new()
        {
            new Jersey { Id = 1, Name = "Home Jersey 2023", Year = "2023", ImageUrl = "jersey_general.jpg", Price = 79.99M },
            new Jersey { Id = 2, Name = "Away Jersey 2023", Year = "2023", ImageUrl = "jersey_2023.jpg", Price = 74.99M },
            new Jersey { Id = 3, Name = "Third Jersey 2024", Year = "2024", ImageUrl = "jersey_2024.jpg", Price = 69.99M }
        };

        public Task<List<Jersey>> GetJerseysAsync()
        {
            return Task.FromResult(_jerseys);
        }

        public Task<Jersey?> GetJerseyByIdAsync(int id)
        {
            return Task.FromResult(_jerseys.Find(j => j.Id == id));
        }
    }
}
