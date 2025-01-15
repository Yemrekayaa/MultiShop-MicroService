using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        [HttpGet("Index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            var values = await ApiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7070/api/Categories");
            return View(values);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Ekle";
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var responseMessage = await ApiService.RequestAsync(HttpMethod.Post, "https://localhost:7070/api/Categories", createCategoryDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet("{id}/Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await ApiService.RequestAsync<object>(HttpMethod.Delete, "https://localhost:7070/api/Categories?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }


        [HttpGet("{id}/Update")]
        public async Task<IActionResult> Update(string id)
        {
            var value = await ApiService.GetAsync<UpdateCategoryDto>("https://localhost:7070/api/Categories/" + id);
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = value.Name;

            return View(value);
        }

        [HttpPost("{id}/Update")]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var responseMessage = await ApiService.RequestAsync(HttpMethod.Put, "https://localhost:7070/api/Categories", updateCategoryDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
