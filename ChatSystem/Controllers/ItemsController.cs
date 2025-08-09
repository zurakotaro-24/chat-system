using ChatSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { name = "keyboarder" };

            return View(item);
        }
    }
}
