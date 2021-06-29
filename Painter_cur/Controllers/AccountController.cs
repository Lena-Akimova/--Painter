using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Painter_cur.Models;

namespace Painter_cur.Controllers
{
    public class AccountController : Controller
    {
        ClientRepository cl_repos;
        ShoppingBask _basket;

        public AccountController(PainterContext _context, IHttpContextAccessor accessor)
        {
            cl_repos = new ClientRepository(_context);
            _basket = new ShoppingBask(_context);
            _basket.SetId(accessor);
        }


        private void MigrateShoppingCart(string UserName)
        {
            HttpContext.Session.SetString("CartId", UserName);
            _basket.BindCart(UserName);
        }


        [HttpGet]
        public IActionResult Exit()
        {
            foreach (var cookie in HttpContext.Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile(string cl_log)
        {
            if (User.Identity.Name != null)
            {
                
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            var cl=cl_repos.GetList().Where(x => x.c_login == cl_log).FirstOrDefault();
            return View(cl);
        }

        [HttpPost]
        public IActionResult Profile([Bind("c_code,c_firstn,c_secondn,c_middlen,c_adress,c_email,c_login,c_password,c_role")] Client user)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            if (user.c_firstn!=null && user.c_adress!=null && user.c_password!=null)
            {
                cl_repos.Update(user);
                ViewData["mes"] = "Данные успешно обновлены :)";
                return View(cl_repos.Get(user.c_code));
            }
            else
            {
                ViewData["mes"] = "Некорректные данные :(";
                var c=cl_repos.Get(user.c_code);
                user.c_login = c.c_login;
                user.c_email = c.c_email;
                return View(user);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Register([Bind("c_code,c_firstn,c_secondn,c_middlen,c_adress,c_email,c_login,c_password,c_role")] Client user)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            if (ModelState.IsValid)
            {
                var cl = cl_repos.GetList().FirstOrDefault(x=>x.c_login==user.c_login);
                var cle = cl_repos.GetList().FirstOrDefault(x => x.c_email == user.c_email);
                if (cl == null && cle == null)
                {
                    cl_repos.Create(user);
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                { 
                    ViewData["mes"] = "Некорректные логин, пароль или эл. почта ";
                }
                    
            }
            return View(user);
        }


        [HttpGet]
        public IActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LogOn(LogOnModel model)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            if (ModelState.IsValid)
            {
                var user=cl_repos.Get(model.UserLogin, model.Password);
          
                if (user != null)
                {
                    await Authenticate(user); 
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewData["mes"] = "Некорректные логин или пароль ";
            return View(model);
        }


        private async Task Authenticate(Client user)
        {
            if (user.c_login != null)
            {
                MigrateShoppingCart(user.c_login);
            }

            var claims = new List<Claim>(){
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.c_login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.c_role)
            };


            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            // установка аутентификационных куки .AspNetCookies
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
