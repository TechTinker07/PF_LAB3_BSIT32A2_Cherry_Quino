using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF_LAB3_BSIT32A2_Cherry_Quino.Data;
using PF_LAB3_BSIT32A2_Cherry_Quino.Models;
using Microsoft.AspNetCore.Authorization;

namespace PF_LAB3_BSIT32A2_Cherry_Quino.Controllers
{
    [Authorize] 
    public class CardsController : Controller
    {
        private readonly GreedDbContext _context;

        public CardsController(GreedDbContext context)
        {
            _context = context;
        }

  
        public async Task<IActionResult> Index()
        {
            var cards = await _context.Cards.ToListAsync();
            return View(cards);
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }

      
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Rarity,CharacterImageUrl,Description")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

  
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var card = await _context.Cards.FindAsync(id);
            if (card == null) return NotFound();

            return View(card);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rarity,CharacterImageUrl,Description")] Card card)
        {
            if (id != card.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
