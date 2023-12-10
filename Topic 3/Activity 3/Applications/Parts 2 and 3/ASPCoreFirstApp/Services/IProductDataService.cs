using ASPCoreFirstApp.Models;

namespace ASPCoreFirstApp.Services
{
    public interface IProductDataService
    {
        List<ProductModel> AllProducts();
        List<ProductModel> SearchProducts(string term);
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);
        bool Delete(int id);
        int Update(ProductModel product);
    }
}
