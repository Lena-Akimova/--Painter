using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Painter_cur.Models;

namespace Painter_cur.Controllers
{
    [Authorize(Roles = "admin,client")]
    public class CheckoutController : Controller
    {
        const string PromoCode = "FREE";
        ProductRepository pr_repos;
        OrderRepository or_repos;
        ClientRepository cl_repos;
        ShoppingBask _basket;
        PainterContext _cont;

        public CheckoutController(PainterContext _context, IHttpContextAccessor accessor)
        {
            pr_repos = new ProductRepository(_context);
            _cont = _context;
            _basket = new ShoppingBask(_context);
            _basket.SetId(accessor);
            cl_repos = new ClientRepository(_context);
            or_repos = new OrderRepository(_context);
        }

        // Get: /Checkout/Payment
        [HttpGet]
        public ActionResult Payment()
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                ViewBag.client = cl_repos.Get(User.Identity.Name);
                ViewData["count"] = _basket.TotalCount();
                ViewData["sum"] = _basket.TotalSum();

                return View("Payment");
            }
            else {
                return RedirectToAction("Account/LogOn");
            }
        }

        [HttpPost]
        public ActionResult Payment( [Bind("o_code,o_date,o_delivery,c_code")] Order order, string promo)
        {

            ViewBag.client = cl_repos.Get(User.Identity.Name);

                if ( string.Equals(promo, PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.o_date = DateTime.Now;
                    or_repos.Create(order);
                    int idd = _basket.CreateOrderPositions(order);
                    
                    return RedirectToAction("Complete", new { id = idd });
                }
        }

        public ActionResult Complete(int id)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            bool isAdded = or_repos.GetList().Any(
                o => o.o_code== id);

            if (isAdded)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult MyOrders()
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

                ViewBag.Counts = new List<int>();
                ViewBag.Sums = new List<decimal>();

                var orders=or_repos.GetList(cl_repos.Get(User.Identity.Name).c_code);

                foreach (var o in orders) {
                    ViewBag.Sums.Add(or_repos.Sum(o));
                    ViewBag.Counts.Add(or_repos.Count(o));
                }

                return View(orders);
            }

            else
            {
                return RedirectToAction("/Account/LogOn");
            }
        }
    }

}
