using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Areas.ViewComponents
{
    public class Admin_NavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
