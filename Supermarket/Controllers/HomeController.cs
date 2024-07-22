using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;

namespace Supermarket.Controllers;

public class HomeController : Controller
{


    public IActionResult Index()
    {
        return View();
    }

 
}
