using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Product_CRUD.Models;
using Product_CRUD.Repository;
using Microsoft.AspNetCore.Http;

namespace Product_CRUD.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult AddProduct()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddModel productAddModel)
        {
           

                if (ModelState.IsValid)
                {
                    var result = await _productRepository.Add(productAddModel);
                    if (result != null)
                    {
                        return RedirectToAction("DashBoard", "Account");
                    }
                    ModelState.AddModelError("", "Something went wrong while add product");
                }
           
            return View(productAddModel);

        }
        public async Task<IActionResult> ViewAll()
        {
            var result = await _productRepository.ViewAll();
            return View(result);
        }

        public async Task<IActionResult> ViewProduct(int id)
        {
            var result = await _productRepository.View(id);
            return View(result);
        }
        public async Task<IActionResult> UpdateProduct(ProductAddModel productAddModel,int id)
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                var result = await _productRepository.Update(productAddModel, id);
                return RedirectToAction("ViewAll", "Product");
            }
          
                 else
                {
                    return RedirectToAction("Login", "Account");
                }
            
        }




    }
}
