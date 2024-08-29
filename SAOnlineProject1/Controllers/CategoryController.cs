using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using System.Threading.Tasks;

namespace SAOnlineProject1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Categories.ToList();

            return View(items);
        }

        [Authorize]
        public IActionResult Upsert(int? id)
        {
            if (id == 0)
            {
                Category category = new Category();
                return View(category);
            }
            else
            {
                var items = _context.Categories.FirstOrDefault(u => u.Id == id);
                return View(items);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(int? id, Category category)
        {
            if (id == null)
            {
                var foundItem = await _context.Categories.FirstOrDefaultAsync(u => u.Name == category.Name);
                if (foundItem != null)
                {
                    TempData["alertMessage"] = category.Name + " is already an existing category. Insertion failed.";
                    return RedirectToAction("Index");
                }
                await _context.Categories.AddAsync(category);
                TempData["alertMessage"] = category.Name + " has been added successfully.";
            }
            else
            {
                var items = _context.Categories.FirstOrDefault(u => u.Id == id);
                items.Name = category.Name;
                TempData["alertMessage"] = category.Name + " has been edited successfully.";
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var items = _context.Categories.FirstOrDefault(u => u.Id == id);
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            var items = _context.Categories.FirstOrDefault(u => u.Id == category.Id);

            _context.Categories.Remove(items);
            TempData["alertMessage"] = category.Name + " has been removed successfully.";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
