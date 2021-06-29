using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Painter_cur.Models;

namespace Painter_cur.Controllers
{
    [Authorize(Roles = "admin")]
    public class StoreManagerController : Controller
    {
        private readonly PainterContext _context;
        private ProductRepository pr_repos;
        private IWebHostEnvironment _appEnvironment;

        public StoreManagerController(PainterContext context, IWebHostEnvironment appEnvironment)
        {
            pr_repos = new ProductRepository(context);
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: StoreManager
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            return View(await _context.Products.ToListAsync());
        }

        // GET: StoreManager/Details/5
        public  IActionResult Details(int id)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            if (id == 0)
            {
                return NotFound();
            }

            var product = pr_repos.Get(id) ;
            if (product == null)
            {
                return NotFound();
            }

            switch (product.P_categ)
            {
                case "Paints":
                    PaintRepository repos = new PaintRepository(_context);
                    ViewBag.KonkProd = repos.Get(id);
                    break;
                case "Brushes":
                    BrushRepository repos1 = new BrushRepository(_context);
                    ViewBag.KonkProd = repos1.Get(id);
                    break;
                case "Papers":
                    PaperRepository repos2 = new PaperRepository(_context);
                    ViewBag.KonkProd = repos2.Get(id);
                    break;
                case "Implements":
                    ImplementRepository repos3 = new ImplementRepository(_context);
                    ViewBag.KonkProd = repos3.Get(id);
                    break;
            }

            return View(product);
        }

        // GET: StoreManager/Create
        public IActionResult Create()
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            ViewBag.Categories =pr_repos.GetListCategories();
            ViewBag.Techiques = pr_repos.GetListTech();
            return View();
        }

        [HttpGet]
        public IActionResult CreateConkr( int part)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            if (part == 0)
            {
                return NotFound();
            }
            Product pr = pr_repos.Get(part);
            if (pr.P_categ == "Papers") {
                ViewBag.Formats = new List<string> { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" };
            }
            ViewBag.Tech = pr_repos.GetTech(part);
            return View(pr);

        }

        [HttpPost]
        public IActionResult CreateConkr(int p_art, [Bind("p_art,pai_type,pai_color,pai_volume,pai_quant")] Paint paint, string colored,[Bind("p_art,b_mater,b_numb,b_form")] Brush brush, [Bind("p_art,pap_type,pap_format,pap_density")] Paper paper, [Bind("p_art,i_type")] Implement imp)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            Product pr = pr_repos.Get(p_art);

            if (ModelState.IsValid)
            {
                switch (pr.P_categ)
                {
                    case "Paints":
                        PaintRepository repos = new PaintRepository(_context);
                        if (colored == "colored") paint.pai_color = "colored";
                        repos.Create(paint);
                        return RedirectToAction(nameof(Index));
                    case "Brushes":
                        BrushRepository repos1 = new BrushRepository(_context);
                        repos1.Create(brush);
                        return RedirectToAction(nameof(Index));
                    case "Papers":
                        PaperRepository repos2 = new PaperRepository(_context);
                        repos2.Create(paper);
                        return RedirectToAction(nameof(Index));
                    case "Implements":
                        ImplementRepository repos3 = new ImplementRepository(_context);
                        repos3.Create(imp);
                        return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Tech = pr_repos.GetTech(p_art);
            ViewData["err"] = "Некорректные данные";
            return View(pr);
        }

        // POST: StoreManager/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("P_art,P_categ,P_name,P_price,P_prod,P_img,P_stock")] Product product, string P_tech, IFormFile P_img)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            if (ModelState.IsValid && P_img!=null)
            {

                string path = "images/" + P_img.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/" + path, FileMode.Create))
                {
                    await P_img.CopyToAsync(fileStream);
                }
                product.P_img = path;
                pr_repos.Create(product);
                pr_repos.ReLoad();
                int part = pr_repos.GetList().Last().P_art;
                pr_repos.CreateTech(new Technique() { p_art = part, t_name = P_tech });
               
                return RedirectToAction(nameof(CreateConkr), new { part });
            }

            ViewBag.Categories = pr_repos.GetListCategories();
            ViewBag.Techiques = pr_repos.GetListTech();
            ViewData["err"] = "Некорректные данные";
            return View(product);
        }

        // GET: StoreManager/Edit/5
        public IActionResult Edit(int id)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            if (id == 0)
            {
                return NotFound();
            }

            var product = pr_repos.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            switch (product.P_categ)
            {
                case "Paints":
                    PaintRepository repos = new PaintRepository(_context);
                    ViewBag.KonkProd = repos.Get(id);
                    break;
                case "Brushes":
                    BrushRepository repos1 = new BrushRepository(_context);
                    ViewBag.KonkProd = repos1.Get(id);
                    break;
                case "Papers":
                    PaperRepository repos2 = new PaperRepository(_context);
                    ViewBag.KonkProd = repos2.Get(id);
                    break;
                case "Implements":
                    ImplementRepository repos3 = new ImplementRepository(_context);
                    ViewBag.KonkProd = repos3.Get(id);
                    break;
            }

            ViewBag.Formats = new List<string> { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" };
            ViewBag.tech = pr_repos.GetTech(id);
            ViewBag.Techiques = pr_repos.GetListTech();
            return View(product);
        }

        // POST: StoreManager/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="P_img"></param>
        /// <param name="P_tech"></param>
        /// <param name="paint"></param>
        /// <param name="colored"></param>
        /// <param name="brush"></param>
        /// <param name="paper"></param>
        /// <param name="imp"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("P_art,P_categ,P_name,P_price,P_prod,P_img,P_stock")] Product product, IFormFile P_img, string P_tech, [Bind("p_art,pai_type,pai_color,pai_volume,pai_quant")] Paint paint, string colored, [Bind("p_art,b_mater,b_numb,b_form")] Brush brush, [Bind("p_art,pap_type,pap_format,pap_density")] Paper paper, [Bind("p_art,i_type")] Implement imp)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            if (id != product.P_art)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (P_img != null)
                {
                    string path = "images/" + P_img.FileName;
                    if (pr_repos.Get(product.P_art).P_img != path)
                    {
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + "/" + path, FileMode.Create))
                        {
                            await P_img.CopyToAsync(fileStream);
                        }
                        product.P_img = path;
                    }
                }

                pr_repos.Update(product);
                pr_repos.UpdateTech(P_tech, id);

                if (paint.pai_type != null || paper.pap_type != null || brush.b_mater != null || imp.i_type != null)
                {
                    switch (product.P_categ)
                    {
                        case "Paints":
                            PaintRepository repos = new PaintRepository(_context);
                            if (colored == "colored") paint.pai_color = "colored";
                            repos.Update(paint);
                            return RedirectToAction(nameof(Index));
                        case "Brushes":
                            BrushRepository repos1 = new BrushRepository(_context);
                            repos1.Update(brush);
                            return RedirectToAction(nameof(Index));
                        case "Papers":
                            PaperRepository repos2 = new PaperRepository(_context);
                            repos2.Update(paper);
                            return RedirectToAction(nameof(Index));
                        case "Implements":
                            ImplementRepository repos3 = new ImplementRepository(_context);
                            repos3.Update(imp);
                            return RedirectToAction(nameof(Index));
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            switch (product.P_categ)
            {
                case "Paints":
                    PaintRepository repos = new PaintRepository(_context);
                    ViewBag.KonkProd = repos.Get(id);
                    break;
                case "Brushes":
                    BrushRepository repos1 = new BrushRepository(_context);
                    ViewBag.KonkProd = repos1.Get(id);
                    break;
                case "Papers":
                    PaperRepository repos2 = new PaperRepository(_context);
                    ViewBag.KonkProd = repos2.Get(id);
                    break;
                case "Implements":
                    ImplementRepository repos3 = new ImplementRepository(_context);
                    ViewBag.KonkProd = repos3.Get(id);
                    break;
            }

            ViewBag.Formats = new List<string> { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" };
            ViewBag.tech = pr_repos.GetTech(id);
            ViewBag.Techiques = pr_repos.GetListTech();
            ViewData["err"] = "Изменения не сохранены. Проверьте веденные данные";
            return View(product);
        }

        // GET: StoreManager/Delete/5
        public IActionResult Delete(int id)
        {
            if (User.Identity.Name != null)
            {
                ViewData["role"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["name"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }
            if (id == 0)
            {
                return NotFound();
            }

            var product = pr_repos.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            switch (product.P_categ)
            {
                case "Paints":
                    PaintRepository repos = new PaintRepository(_context);
                    ViewBag.KonkProd = repos.Get(id);
                    break;
                case "Brushes":
                    BrushRepository repos1 = new BrushRepository(_context);
                    ViewBag.KonkProd = repos1.Get(id);
                    break;
                case "Papers":
                    PaperRepository repos2 = new PaperRepository(_context);
                    ViewBag.KonkProd = repos2.Get(id);
                    break;
                case "Implements":
                    ImplementRepository repos3 = new ImplementRepository(_context);
                    ViewBag.KonkProd = repos3.Get(id);
                    break;
            }

            return View(product);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            pr_repos.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
