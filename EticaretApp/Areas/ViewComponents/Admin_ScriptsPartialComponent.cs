using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Areas.ViewComponents
{
    public class Admin_ScriptsPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
