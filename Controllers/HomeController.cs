using ElectricInventorySystem.Controllers;
using Microsoft.AspNetCore.Mvc;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}