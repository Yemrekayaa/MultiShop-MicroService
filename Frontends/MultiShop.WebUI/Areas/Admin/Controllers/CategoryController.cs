using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {

        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            var datas = await ApiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7070/api/Categories");
            return View(datas);
        }
    }
}
