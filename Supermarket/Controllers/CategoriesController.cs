using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;

namespace Supermarket.Controllers;


public class CategoriesController : Controller
{
    public IActionResult Index()
    {

        //gert categories
        //show it in view
        var category = CategoryRepository.GetCategories();
        return View(category);
    }

    public IActionResult Edit(int? id)

    {  
        ViewBag.action = "edit";
        var category = CategoryRepository.GetCategoryById(id.HasValue? id.Value : 0);
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)

    {  
        ViewBag.action = "edit";
        if (ModelState.IsValid)
        {
        CategoryRepository.UpdateCategory(category.CategoryId,category);
        return RedirectToAction(nameof(Index));
        }

        return View(category);

    }

    public IActionResult Add()

    {  
        ViewBag.action = "add";
        return View();
    }

    [HttpPost]
    public IActionResult Add(Category category)

    {  
        ViewBag.action = "add";
        if (ModelState.IsValid)
        {
        CategoryRepository.AddCategory(category);
        return RedirectToAction(nameof(Index));
        }

        return View();
    }

    [HttpPost]
    public IActionResult Delete( int? id)
    {  


        var category = CategoryRepository.GetCategoryById(id.HasValue? id.Value : 0);
        if (category != null)
        {
        CategoryRepository.DeleteCategory(category.CategoryId);
        
        }

        return RedirectToAction(nameof(Index));
        

    }


}
