using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreFirstApp.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            HardCodedCarDataService carRepository = new HardCodedCarDataService();
            return View(carRepository.AllCars());
        }
    }
}
