using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Areas.ViewComponents
{
    public class Admin_HeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
