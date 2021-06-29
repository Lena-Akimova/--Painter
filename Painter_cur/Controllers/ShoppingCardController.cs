using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Painter_cur.Models;
using Painter_cur.ViewModels;

namespace Painter_cur.Controllers
{
    public class ShoppingCardController : Controller
    {
        ShoppingBask _basket;

        public ShoppingCardController(PainterContext _context, IHttpContextAccessor accessor)
        {
            _basket = new ShoppingBask(_context);
            _basket.SetId(accessor);
        }

        public IActionResult Index( )
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                ViewData["kol"] = _basket.TotalCount();
            }

            ViewData["kol"] = _basket.TotalCount();
            var viewModel = new ShoppingCardViewModel
            {
                BaskPositions = _basket.GetBasket(),
                BaskProducts = _basket.GetProducts(),
                TotalSum = _basket.TotalSum(),
                TotalCount = _basket.TotalCount()
            };
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult AddToCart(int p_art, int kol)
        {
            _basket.AddToBask(p_art, kol);
            var res = new { TotalCount = _basket.TotalCount() };
            return Json(res);
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public JsonResult RemoveFromCart(int p_art)
        {
            int pos_count = _basket.Reduce(p_art);

            var results = new ShoppingCartRemoveViewModel
            {
                TotalSum=_basket.TotalSum(),
                TotalCount=_basket.TotalCount(),
                PosCount=pos_count,
                DeleteP_art=p_art
            };
            return Json(results);
        }


        [HttpPost]
        public JsonResult ClearCart(int b_code)
        {
           _basket.ClearBask();

            var results = new ShoppingCartRemoveViewModel
            {
                TotalSum =0,
                TotalCount =0,
                PosCount =0,
                DeleteP_art =0
            };
            return Json(results);
        }

        [HttpPost]
        public JsonResult ClearCartPos(int p_art)
        {
            _basket.Delete(p_art);

            var results = new ShoppingCartRemoveViewModel
            {
                TotalSum = _basket.TotalSum(),
                TotalCount = _basket.TotalCount(),
                PosCount = 0,
                DeleteP_art = p_art
            };
            return Json(results);
        }

        [HttpPost]
        public JsonResult AddOneToCart(int p_art)
        {
            int pos_count = _basket.Increase(p_art);

            var results = new ShoppingCartRemoveViewModel
            {
                TotalSum = _basket.TotalSum(),
                TotalCount = _basket.TotalCount(),
                PosCount = pos_count,
                DeleteP_art = p_art
            };
            return Json(results);
        }


        public JsonResult TotalCount()
        {
            return Json(new { tc=_basket.TotalCount() });
        }
    }
}
