using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCB.Models;

namespace QLCB.Controllers
{
    public class SanBayController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SanBayController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: SanBay
        public async Task<IActionResult> Index()
        {
            var sanBays = await _context.SanBays.ToListAsync();
            return View(sanBays);
        }

        // GET: SanBay/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanBay/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanBay sanBay)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(sanBay);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Thêm lỗi chung vào ModelState để hiển thị ở view
                    ModelState.AddModelError(string.Empty, "Lỗi khi lưu dữ liệu: " + ex.Message);
                }
            }
            // Nếu ModelState không hợp lệ hoặc có lỗi khi lưu thì trả lại view kèm dữ liệu nhập
            return View(sanBay);
        }


        // GET: SanBay/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var sanBay = await _context.SanBays.FindAsync(id);
            if (sanBay == null)
                return NotFound();

            return View(sanBay);
        }

        // POST: SanBay/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SanBay sanBay)
        {
            if (id != sanBay.MaSanBay)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanBay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanBayExists(sanBay.MaSanBay))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sanBay);
        }

        // GET: SanBay/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var sanBay = await _context.SanBays
                .FirstOrDefaultAsync(m => m.MaSanBay == id);
            if (sanBay == null)
                return NotFound();

            return View(sanBay);
        }

        // POST: SanBay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanBay = await _context.SanBays.FindAsync(id);
            if (sanBay != null)
            {
                _context.SanBays.Remove(sanBay);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SanBayExists(string id)
        {
            return _context.SanBays.Any(e => e.MaSanBay == id);
        }
    }
}
