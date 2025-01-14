using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : AdminBaseController
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
