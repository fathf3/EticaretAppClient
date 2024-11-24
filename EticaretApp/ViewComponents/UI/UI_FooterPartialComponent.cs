using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.ViewComponents.UI
{
    public class UI_FooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
