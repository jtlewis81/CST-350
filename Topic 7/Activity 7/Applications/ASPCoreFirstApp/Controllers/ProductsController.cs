﻿using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreFirstApp.Controllers
{
    public class ProductsController : Controller
    {
        //HardCodedSampleDataRepository repository = new HardCodedSampleDataRepository();
        //ProductsDAO repository = new ProductsDAO();

        IProductDataService repository { get; set; }
        
        public ProductsController(IProductDataService dataService)
        {
            repository = dataService;
        }

        //public ProductsController()
        //{
        //    repository = new ProductsDAO();
        //}

        public IActionResult Index()
        {
            return View(repository.AllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return View("Index", productList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult ShowOneProduct(int id)
        {
            return View(repository.GetProductById(id));
        }

        public IActionResult ShowOneProductJSON(int id)
        {
            return Json(repository.GetProductById(id));
        }

        public IActionResult ShowEditForm(int id)
        {
            return View(repository.GetProductById(id));
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return View("Index", repository.AllProducts());
        }

        public IActionResult ProcessEditreturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("Index", repository.AllProducts());
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            ViewBag.name = "JT";
            ViewBag.secretNumber = 8;
            return View();
        }
    }
}
