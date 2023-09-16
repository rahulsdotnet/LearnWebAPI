using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ITeaService _teaService;
        public RestaurantService(ITeaService teaService)
        {
            _teaService = teaService;
        }

        public string GetTea()
        {
            return _teaService.GetTea();
        }
    }

    public interface IRestaurantService
    {
        string GetTea();
    }
}
