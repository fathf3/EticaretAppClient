using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Areas.ViewComponents
{
    public class Admin_FooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
