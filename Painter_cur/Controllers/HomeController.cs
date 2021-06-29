using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Painter_cur.Models;

namespace Painter_cur.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ProductRepository pr_repos;
        PainterContext _cont;

        public HomeController(PainterContext _context)
        {
            pr_repos = new ProductRepository(_context);
            _cont = _context;
        }

        public IActionResult Index()
        {
            
            if ( User.Identity.Name!=null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            List<Product> pr = pr_repos.GetList();
            if (pr == null) return View();
            var top = pr_repos.GetTopSellingProducts();

            ViewBag.New=pr_repos.GetList().Where(x => pr_repos.HasKonkr(x)).LastOrDefault();

            if(top!=null)
            return View(pr_repos.TableView(top, 4));

            return View(pr_repos.TableView(pr, 4));

        }


        public IActionResult Interesting()
        {
            if (User.Identity.Name != null )
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            var pr = pr_repos.GetListProdOfTech("Акварель").Take(6).ToList();
            return View(pr);
        }
        public IActionResult Delivery()
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            return View();
        }
        public IActionResult Payment()
        {
            if (User.Identity.Name != null )
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
