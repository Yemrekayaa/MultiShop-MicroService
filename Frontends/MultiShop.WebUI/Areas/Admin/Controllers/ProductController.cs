using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        [HttpGet("Index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "ürün Listesi";
            var values = await ApiService.GetAsync<List<ResultProductDto>>("https://localhost:7070/api/Products");
            return View(values);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Ekle";

            var categoryValues = await ApiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7070/api/Categories");
            List<SelectListItem> categoryList = (from x in categoryValues
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id
                                                 }).ToList();
            ViewBag.categoryList = categoryList;
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var responseMessage = await ApiService.RequestAsync(HttpMethod.Post, "https://localhost:7070/api/Products", createProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await ApiService.RequestAsync<object>(HttpMethod.Delete, "https://localhost:7070/api/Products?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }


        [HttpGet("{id}/Update")]
        public async Task<IActionResult> Update(string id)
        {
            var value = await ApiService.GetAsync<UpdateProductDto>("https://localhost:7070/api/Products/" + id);
            var categoryValues = await ApiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7070/api/Categories");
            List<SelectListItem> categoryList = (from x in categoryValues
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id
                                                 }).ToList();
            ViewBag.categoryList = categoryList;

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = value.Name;

            return View(value);
        }

        [HttpPost("{id}/Update")]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var responseMessage = await ApiService.RequestAsync(HttpMethod.Put, "https://localhost:7070/api/Products", updateProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
