using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamingPlatform.Data;
using StreamingPlatform.Models;


namespace StreamingPlatform.Controllers
{
    public class MusicVideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicVideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MusicVideos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MusicVideo.Include(m => m.Artist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MusicVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicVideo = await _context.MusicVideo
                .Include(m => m.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicVideo == null)
            {
                return NotFound();
            }

            return View(musicVideo);
        }

        // GET: MusicVideos/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Title", "Title");
            return View();
        }

        // POST: MusicVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ArtistId,Duration,ReleaseDate")] MusicVideo musicVideo)
        {
            ModelState.Remove("Artist");
            if (ModelState.IsValid)
            {
                _context.Add(musicVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", musicVideo.ArtistId);
            return View(musicVideo);
        }

        // GET: MusicVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicVideo = await _context.MusicVideo.FindAsync(id);
            if (musicVideo == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", musicVideo.ArtistId);
            return View(musicVideo);
        }

        // POST: MusicVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ArtistId,Duration,ReleaseDate")] MusicVideo musicVideo)
        {
            if (id != musicVideo.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Artist");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicVideoExists(musicVideo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Title", "Title", musicVideo.ArtistId);
            return View(musicVideo);
        }

        // GET: MusicVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicVideo = await _context.MusicVideo
                .Include(m => m.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicVideo == null)
            {
                return NotFound();
            }

            return View(musicVideo);
        }

        // POST: MusicVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicVideo = await _context.MusicVideo.FindAsync(id);
            if (musicVideo != null)
            {
                _context.MusicVideo.Remove(musicVideo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicVideoExists(int id)
        {
            return _context.MusicVideo.Any(e => e.Id == id);
        }
    }
}
