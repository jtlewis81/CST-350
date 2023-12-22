using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace ASPCoreFirstApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsAPIController : ControllerBase
    {

        ProductsDAO repository = new ProductsDAO();

        public ProductsAPIController()
        {
            repository = new ProductsDAO();
        }

        [HttpGet]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index()
        {
            List<ProductModel> productList = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOs = from p in productList
                                                  select new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOs;
        }

        [HttpGet("searchresults/{searchTerm}")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            IEnumerable<ProductDTO> productDTOs = from p in productList
                                                  select new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOs;
        }

        [HttpGet("showoneproduct/{id}")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult <ProductDTO> ShowOneProduct(int id)
        {
            ProductModel product = repository.GetProductById(id);
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);
            return productDTO;
        }

        [HttpPut("processedit")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            List<ProductModel> productList = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOs = from p in productList
                                                  select new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOs;
        }

        [HttpPut("processeditreturnoneitem")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult <ProductDTO> ProcessEditReturnOneItem(ProductModel product)
        {
            repository.Update(product);
            ProductModel updatedProduct = repository.GetProductById(product.Id);
            ProductDTO productDTO = new ProductDTO(updatedProduct.Id, updatedProduct.Name, updatedProduct.Price, updatedProduct.Description);
            return productDTO;
        }

        [HttpDelete("delete/{id}")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Delete(int id)
        {
            repository.Delete(id);
            List<ProductModel> productList = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOs = from p in productList
                                                  select new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOs;
        }

    }
}
