using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ChatApp.WebServer
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;



        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            //TODO remove work time db creation
            _context.Database.EnsureCreated();

            return View();
        }

        [Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            var result = await _signInManager.PasswordSignInAsync("redwinter", "redredred", true, false);
            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Index));
                return Redirect(returnUrl);
            }

            return Content("something very wrong");
        }

        [Route("logout")]
        public async Task<IActionResult> LogoutAsync(string returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Content("done");
        }

        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var task = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Redwinter",
                Email = "Redwinter@Redwinter.com",
                FirstName = "Alexander",
                LastName = "Redwinter"
            },"redredred10_YYaa");

            if (task.Succeeded)
            {
                return Content("created", "text/html");
            }

            return Content("not created", "text/html");
        }
    }
}
