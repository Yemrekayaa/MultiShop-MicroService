using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class AdminBaseController : Controller
    {
        private ApiService _apiService;
        protected ApiService ApiService => _apiService ??= HttpContext.RequestServices.GetService<ApiService>();
    }
}
