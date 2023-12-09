using ASPCoreFirstApp.Models;
using Bogus;

namespace ASPCoreFirstApp.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        static List<ProductModel> productList;

        public HardCodedSampleDataRepository()
        {
            productList = new List<ProductModel>();

            productList.Add(new ProductModel(1, "Nvidia RTX 2070 Super", 450.00m, "Second-hand GPU bought on Facebook Marketplace"));
            productList.Add(new ProductModel(2, "Ryzen 7 3700X", 300.00m, "8-Core Multi-threaded 3.6/4.3 GHz CPU"));
            productList.Add(new ProductModel(3, "Lian Li LanCool 2", 100.00m, "Full Tower PC Case w/ tempered glass side panel and 3 RGB fans"));
            productList.Add(new ProductModel(4, "G.Skill DDR4 - 32 GB (2x16)", 160.00m, "Dual-Channel RAM Kit w/ RGB"));

            for (int i = 0; i < 100; i++)
            {
                productList.Add(new Faker<ProductModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.Description, f => f.Rant.Review())
                    );
            }
            Console.Write(productList.Count);
        }

        public List<ProductModel> AllProducts()
        {
            return productList;
        }

        public bool Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string term)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
