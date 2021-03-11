using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_3_6.Models.DataBase;

namespace Web_3_6.Controllers
{

    public class AuthController : Controller
    {
        public Context db = null;

        public AuthController(Context context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            if (User.Claims.ToList().Count > 0)
                return RedirectToAction("index", "issues");
            return View("auth");
        }


        [HttpGet]
        public IActionResult Registr()
        {
            return View("Registr");
        }
        
        [HttpPost]
        public async Task<IActionResult> Registr(string userName, string pass, int role = 1)
        {
            User user = await db.users.FirstOrDefaultAsync(u => u.login == userName);
            if (user == null)
            {
                // добавляем пользователя в бд
                db.users.Add(new User { login = userName, pass = pass, role = role });
                await db.SaveChangesAsync();

                await Authenticate(userName, role); // аутентификация

                //return Ok();
                return RedirectToAction("Index", "issues");
            }

            return View("Registr");
        }

        private async Task Authenticate(string userName, int role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public async Task<IActionResult> Login(string userName, string pass)
        {
            User user = await db.users.FirstOrDefaultAsync(u => u.login == userName && u.pass == pass);
            if (user != null)
            {
                await Authenticate(userName, user.role); // аутентификация
                
                return RedirectToAction("Index", "issues");
            }

            return View("auth");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "auth");
        }
    }
}
