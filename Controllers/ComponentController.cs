using Microsoft.AspNetCore.Mvc;
using ElectricInventorySystem.Data;
using ElectricInventorySystem.Models;
using System.Linq;

namespace ElectricInventorySystem.Controllers
{
    public class ComponentController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public ComponentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var data = _context.Components.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(c =>
                    c.ProductName.Contains(search) ||
                    c.ComponentName.Contains(search) ||
                    c.PartNo.Contains(search));
            }

            return View(data.ToList());
        }

        public IActionResult Create()
        {
            if (CurrentRole != "Admin" && CurrentRole != "Editor")
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Component component)
        {
            if (CurrentRole != "Admin" && CurrentRole != "Editor")
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Components.Add(component);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(component);
        }

        public IActionResult Edit(int id)
        {
            if (CurrentRole != "Admin" && CurrentRole != "Editor")
                return RedirectToAction("Index");

            var component = _context.Components.Find(id);
            if (component == null) return NotFound();

            return View(component);
        }

        [HttpPost]
        public IActionResult Edit(Component component)
        {
            if (CurrentRole != "Admin" && CurrentRole != "Editor")
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Components.Update(component);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(component);
        }

        public IActionResult Delete(int id)
        {
            if (CurrentRole != "Admin")
                return RedirectToAction("Index");

            var component = _context.Components.Find(id);
            if (component == null) return NotFound();

            return View(component);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (CurrentRole != "Admin")
                return RedirectToAction("Index");

            var component = _context.Components.Find(id);

            if (component != null)
            {
                _context.Components.Remove(component);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}