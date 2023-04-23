using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using static Application.Cars.GetCars;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AlcoholController : Controller
    {
        [HttpPost]
        public async Task<bool> GetAlcoTest(AlcoholDto data)
        {
            var alcoholConsumed = data.Quantity;
            var weight = data.Weight;
            var gender = data.Gender;
            var hoursSinceLastDrink = data.MinutesAfter;
            var alcoholInGrams = alcoholConsumed * 0.8 * 0.01;
            double r = gender == "M" ? 0.68 : 0.55;
            double bloodAlcoholContent = (double)((alcoholInGrams / (weight * r)) * 100 - (0.15 * (hoursSinceLastDrink / 60)));
            if (bloodAlcoholContent <= 0.3 && bloodAlcoholContent >= 0)
            {
                return true;
            }
            else return false;
        }
    }
}
