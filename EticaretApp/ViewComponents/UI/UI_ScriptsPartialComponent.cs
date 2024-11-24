using Microsoft.AspNetCore.Mvc;

namespace EticaretApp.ViewComponents.UI
{
    public class UI_ScriptsPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
