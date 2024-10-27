using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_lab2.Data;
using Cirlig_Bianca_lab2.Models;

namespace Cirlig_Bianca_lab2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context _context;

        public EditModel(Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;

            Authors = await _context.Authors
                .Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                })
                .ToListAsync();

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                Authors = await _context.Authors
                    .Select(a => new SelectListItem
                    {
                        Value = a.ID.ToString(),
                        Text = $"{a.FirstName} {a.LastName}"
                    })
                    .ToListAsync();

                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
