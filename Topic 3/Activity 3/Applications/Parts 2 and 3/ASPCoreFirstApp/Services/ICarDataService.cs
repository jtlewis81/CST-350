using ASPCoreFirstApp.Models;

namespace ASPCoreFirstApp.Services
{
    public interface ICarDataService
    {
        List<CarModel> AllCars();
        List<CarModel> SearchCars(string term);
        CarModel GetCarById(int id);
        int Insert(CarModel product);
        bool Delete(CarModel product);
        int Update(CarModel product);
    }
}