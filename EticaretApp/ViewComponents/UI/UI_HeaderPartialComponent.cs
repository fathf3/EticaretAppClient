using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.ViewComponents.UI
{

    public class UI_HeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
