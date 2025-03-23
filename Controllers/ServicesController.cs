using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyParlourManagementSystemAPI.Data;
using BeautyParlourManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyParlourManagementSystemAPI.Controllers
{
    [Route("[controller]")]
    public class ServicesController : Controller
    {
        private readonly BeautyParlourManagementSystemAPIContext _context;

        public ServicesController(BeautyParlourManagementSystemAPIContext context)
        {
            _context = context;
        }

        // GET: Services
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();
            return View(services); // Returns the list view of services
        }

        // GET: Services/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service); // Returns the details view of a specific service
        }

        // GET: Services/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new service
        }

        // POST: Services/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Services service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the service list
            }
            return View(service);
        }

        // GET: Services/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service); // Returns the edit view for a specific service
        }

        // POST: Services/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Services service)
        {
            if (id != service.ServiceID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the service list
            }
            return View(service);
        }

        // GET: Services/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service); // Returns the delete confirmation view
        }

        // POST: Services/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the service list
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceID == id);
        }
    }
}
