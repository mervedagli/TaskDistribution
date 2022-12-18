using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskDistribution.Data.Modals;
using TaskDistribution.Repositories;

namespace TaskDistribution.Controllers
{
    //[Route("/[controller]/[action]")]
    public class LoginController : Controller
    {
        private ILoginRepository _loginRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public LoginController(ILoginRepository loginRepository, IHttpContextAccessor httpContextAccessor)
        {
            _loginRepository = loginRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Login/Index")]
        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.User.FindFirst(ClaimTypes.Name);
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if (user is not null)
            {
                var userEntity =await _loginRepository.GetByFilter(x=>x.User_NM== user.User_NM && x.Password_TXT==user.Password_TXT, "UserRole");
                if (userEntity != null)
                {
                    //var claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name,userEntity.User_NM),
                    //     new Claim(ClaimTypes.Role, userEntity.UserRole.UserRole_NM),
                    //};
                    ////var userIdentity=new ClaimsIdentity(claims,"Login");
                    ////ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    ////await HttpContext.SignInAsync(principal);

                    //var identity = new ClaimsIdentity(claims,"a");


                    ////identity.AddClaim(new Claim(ClaimTypes.Name, userEntity.User_NM));
                    ////identity.AddClaim(new Claim(ClaimTypes.Role, userEntity.UserRole.UserRole_NM));

                    //var principal = new ClaimsPrincipal(identity);

                    //var authProperties = new AuthenticationProperties
                    //{
                    //    AllowRefresh = true,
                    //    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    //    IsPersistent = true,
                    //};

                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    HttpContext.Session.SetString("username", userEntity.UserRole.UserRole_NM);
                    ViewBag.sessionRole=HttpContext.Session.GetString("username");
                    return  RedirectToAction("Index","Task");

                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
