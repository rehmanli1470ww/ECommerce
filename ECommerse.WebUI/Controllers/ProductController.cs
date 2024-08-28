using ECommerce.Business.Abstaract;
using ECommerse.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        public string Sort { get; set; } = "A - Z";
        public string Lower { get; set; } = "To Lower";
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(int page=1,int category=0, string sort= "",string lower= "")
        {
            int pageSize = 10;
            var items=await _productService.GetAllByCategoryAsync(category);
            var products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
           

            if (sort=="A - Z")
            {
                Sort = "Z - A";
                products=products.OrderBy(p=>p.ProductName).ToList();
            }else if (sort== "Z - A")
            {
                Sort = "A - Z";
                products = products.OrderByDescending(p => p.ProductName).ToList();
            }

            if (lower=="To Lower")
            {
                Lower = "To Upper";
                foreach (var product in products)
                {
                    product.ProductName = product.ProductName.ToLower();
                }
            }
            else if (lower== "To Upper")
            {
                Lower = "To Lower";
                foreach (var product in products)
                {
                    product.ProductName = product.ProductName.ToUpper();
                }
            }
            var model = new ProductListViewModel
            {
                Products = products,
                CurrentCategory = category,
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page,
                SortProduct = Sort,
                LowerUpperBtn = Lower
            };
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
