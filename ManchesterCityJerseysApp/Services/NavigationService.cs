﻿using ManchesterCityJerseys.Core.Interfaces;

namespace ManchesterCityJerseysApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
