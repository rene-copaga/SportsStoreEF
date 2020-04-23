﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo) => repository = repo;

        public IActionResult Index()
        {
            return View(repository.Products);
        }

        public IActionResult UpdateProduct(long key)
        {
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.Id == 0)
            {
                repository.AddProduct(product);
            }
            else
            {
                repository.UpdateProduct(product);
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
