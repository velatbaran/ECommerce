using ECommerce.Bussiness.Abstract;
using ECommerce.Entities;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(new ListCategoryModel()
            {
                Categories = _categoryService.GetAll(x => x.IsDeleted == false)
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Name = model.Name,
                    CreatedDate = DateTime.Now,
                    CreatedUsername = "wbaran"
                };

                if (_categoryService.Create(category) > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Kayıt yapılırken hata oluştu.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Category category = _categoryService.GetById(id.Value);
            Category category = _categoryService.GetCategoryWithProducts(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            var cat = new CategoryModel()
            {
                Name = category.Name,
                Id = category.Id,
                Products = category.ProductsAndCategories.Select(x => x.Product).ToList()
            };
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category cat = _categoryService.GetById(model.Id);
                cat.Name = model.Name;
                cat.ModifiedDate = DateTime.Now;
                cat.ModifiedUsername = "wbaran";

                if (_categoryService.Update(cat) > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Güncelleme yapılırken hata oluştu.");
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedUsername = "wbaran";
            if (_categoryService.Delete(category) > 0)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Silme işlemi yapılırken hata oluştu.");
            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteProductFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteProductFromCategory(categoryId, productId);
            return Redirect("/Category/Edit/" + categoryId);
        }
    }
}
