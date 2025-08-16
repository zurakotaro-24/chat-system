using System.Diagnostics;
using System.Threading.Tasks;
using ChatSystem.Data;
using ChatSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyAppContext _context;

        public HomeController(ILogger<HomeController> logger, MyAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.UserInformations
                .Include(ua => ua.userAccount)
                .ToListAsync();
            return View();
        }

        public IActionResult Signup()
        {
            var model = new SignUpModel()
            {
                userAcc = new UserAccount(),
                userInfo = new UserInformation()
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if(ModelState.IsValid)
            {
                model.userInfo.userAccount = model.userAcc;
                _context.UserInformations.Add(model.userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
