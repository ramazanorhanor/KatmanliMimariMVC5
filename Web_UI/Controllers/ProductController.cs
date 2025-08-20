using Service_Katmani.Abstract;
using Service_Katmani.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_UI.Controllers
{
    /// <summary>
    /// Nedir: Product için MVC Controller
    /// Amaç: UI’den gelen CRUD taleplerini Service katmanına yönlendirmek
    /// Ne işe yarar: JSON ve View ile kullanıcıya veri sunar
    /// Enterprise Best Practice: CSRF koruması, async ve AJAX uyumlu, DTO kullanımı
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        // Constructor Injection (Autofac ile register edilmiş)
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            var products = _productService.GetAllProducts()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(ProductDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed" });

            _productService.AddProduct(dto);
            return Json(new { success = true, message = "Product added successfully" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Update(ProductDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Geçersiz veri" });

            _productService.UpdateProduct(dto);
            return Json(new { success = true });
        }
        // [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            //https://localhost:44397/Product/Delete/3
            _productService.DeleteProduct(id);
            return Json(new { success = true });
        }
    }
}