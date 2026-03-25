using ElectricInventorySystem.Controllers;
using ElectricInventorySystem.Data;
using ElectricInventorySystem.Models;
using Microsoft.AspNetCore.Mvc;

public class SupplierController : BaseController
{
    private readonly ApplicationDbContext _context;

    public SupplierController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string search)
    {
        var suppliers = _context.Suppliers.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            suppliers = suppliers.Where(s => s.Name.Contains(search));
        }

        return View(suppliers.ToList());
    }

    public IActionResult Create()
    {
        if (CurrentRole != "Admin" && CurrentRole != "Editor")
            return RedirectToAction("Index");

        return View();
    }

    [HttpPost]
    public IActionResult Create(Supplier supplier)
    {
        if (CurrentRole != "Admin" && CurrentRole != "Editor")
            return RedirectToAction("Index");

        if (ModelState.IsValid)
        {
            supplier.CreatedAt = DateTime.Now;
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(supplier);
    }

    public IActionResult Delete(int id)
    {
        if (CurrentRole != "Admin")
            return RedirectToAction("Index");

        var supplier = _context.Suppliers.Find(id);
        if (supplier == null) return NotFound();

        return View(supplier);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int SupplierId)
    {
        if (CurrentRole != "Admin")
            return RedirectToAction("Index");

        var supplier = _context.Suppliers.Find(SupplierId);

        if (supplier != null)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}