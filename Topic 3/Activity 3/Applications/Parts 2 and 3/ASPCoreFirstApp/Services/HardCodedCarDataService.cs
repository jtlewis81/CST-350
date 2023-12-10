using ASPCoreFirstApp.Models;

namespace ASPCoreFirstApp.Services
{
    public class HardCodedCarDataService : ICarDataService
    {
        static List<CarModel> carList;

        public HardCodedCarDataService()
        {
            carList = new List<CarModel>();

            AllCars().Add(new CarModel(1, "Dodge Viper RT/10", new DateTime(1992, 1, 1), 50000));
            AllCars().Add(new CarModel(2, "Mitsubishi Eclipse GT", new DateTime(2004, 1, 1), 2000));
            AllCars().Add(new CarModel(3, "Mini Cooper S", new DateTime(2006, 1, 1), 3000));
            AllCars().Add(new CarModel(3, "Nissan GT-R", new DateTime(2024, 1, 1), 121000));
        }

        public List<CarModel> AllCars()
        {
            return carList;
        }

        public bool Delete(CarModel product)
        {
            throw new NotImplementedException();
        }

        public CarModel GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(CarModel product)
        {
            throw new NotImplementedException();
        }

        public List<CarModel> SearchCars(string term)
        {
            throw new NotImplementedException();
        }

        public int Update(CarModel product)
        {
            throw new NotImplementedException();
        }
    }
}
