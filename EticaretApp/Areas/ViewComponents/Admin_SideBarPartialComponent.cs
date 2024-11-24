using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.Areas.ViewComponents
{
    public class Admin_SideBarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
