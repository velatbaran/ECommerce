using ECommerce.Bussiness.Abstract;
using ECommerce.Entities;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(new ListProductModel()
            {
                Products = _productService.GetAll(x => x.IsDeleted == false)
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View(new ProductModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel model, int[] categoryIds, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    model.Image = Image.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", Image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                }
                else
                {
                    model.Image = "resim-yok.png";
                }
                Product product = new Product()
                {
                    Name = model.Name,
                    Image = model.Image,
                    Amount = model.Amount,
                    IsStock = model.IsStock,
                    Description = model.Description,
                    Price = model.Price,
                    CreatedDate = DateTime.Now,
                    CreatedUsername = "wbaran"
                };

                if (_productService.Create(product, categoryIds) > 0)
                    return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetCategoriesWithProductId(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            ProductModel model = new ProductModel()
            {
                SelectedCategories = entity.ProductsAndCategories.Select(x => x.Category).ToList(),
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                Amount = entity.Amount,
                Image = entity.Image,
                IsStock = entity.IsStock
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModel model, int[] categoryIds, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                Product entity = _productService.GetById(model.Id);
                if (Image != null)
                {
                    entity.Image = Image.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", Image.FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                }

                entity.Name = model.Name;
                entity.Amount = model.Amount;
                entity.IsStock = model.IsStock;
                entity.Description = model.Description;
                entity.Price = model.Price;

                if (_productService.Update(entity, categoryIds) > 0)
                    return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }            
            product.IsDeleted = true;
            product.DeletedDate = DateTime.Now;
            product.DeletedUsername = "wbaran";
            if (_productService.Delete(product) > 0)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetail(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return PartialView("ProductDetailModal", new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductsAndCategories.Select(x => x.Category).ToList()
            });

        }
    }
}
