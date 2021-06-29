using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Painter_cur.Models;

namespace Painter_cur.Controllers
{
    [AllowAnonymous]
    public class StoreController : Controller
    {
        ProductRepository pr_repos;
        PainterContext _cont;

        public StoreController(PainterContext _context)
        {
            pr_repos = new ProductRepository(_context);
            _cont = _context;
        }
        /// <summary>
        /// Выдает результат поиска или фильтрации 
        /// <a href="https://vk.com/id112461524">Вконтакте</a>
        /// <see cref="M:Painter_cur.Models.ProductRepository.Get(System.Int32)"></see>
        /// </summary>
        /// <param name="tech"></param>
        /// <param name="categ"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public IActionResult Browse(string tech="", string categ="", string q="" )
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            if (!String.IsNullOrEmpty(q))
            {
                q = q.ToLower();
                var res = pr_repos.GetList().Where(s => s.P_name.ToLower().Contains(q)||s.P_prod.ToLower().Contains(q)||s.P_categ.ToLower().Contains(q)).ToList();
                res= res.Where(x => pr_repos.HasKonkr(x)).ToList();
                if (res.Count != 0)
                    return View(pr_repos.TableView(res, 4));
                else {
                    ViewBag.empty = "По запросу не найдено совпадений :(";
                    return View();
                }
            }

            List<Product> pr=new List<Product>();
            if (categ != "" && tech == "" )
            {
                string c ="";
                switch (categ)
                {
                    case "Paints":
                        c = "Краски";
                        break;
                    case "Brushes":
                        c = "Кисточки";
                        break;
                    case "Papers":
                        c = "Бумага";
                        break;
                    case "Implements":
                        c = "Другое";
                        break;
                    default:
                        c = categ;
                        break;
                }

                    ViewData["Category"] = c;
                    pr = pr_repos.GetList(categ).Where(x => pr_repos.HasKonkr(x)).ToList();
                    return View(pr_repos.TableView(pr, 4));
            }
            
            else if (categ == "" && tech != "")
            {
                ViewData["Category"] = tech;
                pr = pr_repos.GetListProdOfTech(tech).Where(x => pr_repos.HasKonkr(x)).ToList(); ;
                return View(pr_repos.TableView(pr, 4));
            }

            else 
            {
                ViewData["Category"] = "Всё";
                pr = pr_repos.GetList().Where(x => pr_repos.HasKonkr(x)).ToList(); ;
                return View(pr_repos.TableView(pr, 4));
            }
        }


        public IActionResult Deteils(int p_art)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            Product pr = pr_repos.Get(p_art);
            ViewData["Category"] = pr.P_categ;

            switch (pr.P_categ)
            {
                case "Paints":
                    PaintRepository repos = new PaintRepository(_cont);
                    ViewBag.KonkProd = repos.Get(p_art);
                    break;
                case "Brushes":
                    BrushRepository repos1 = new BrushRepository(_cont);
                    ViewBag.KonkProd = repos1.Get(p_art);
                    break;
                case "Papers":
                    PaperRepository repos2 = new PaperRepository(_cont);
                    ViewBag.KonkProd = repos2.Get(p_art);
                    break;
                case "Implements":
                    ImplementRepository repos3 = new ImplementRepository(_cont);
                    ViewBag.KonkProd = repos3.Get(p_art);
                    break;
            }
            return View(pr);
        }


        public IActionResult Catalog()
        {
            if (User.Identity.Name != null )
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            return View();
        }
        
    }
}
