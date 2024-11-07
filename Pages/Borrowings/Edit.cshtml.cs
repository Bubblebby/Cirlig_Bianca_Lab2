using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_Lab2.Data;
using Cirlig_Bianca_Lab2.Models;

namespace Cirlig_Bianca_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Cirlig_Bianca_Lab2.Data.Cirlig_Bianca_Lab2Context _context;

        public EditModel(Cirlig_Bianca_Lab2.Data.Cirlig_Bianca_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }

            Borrowing = borrowing;

            var bookList = _context.Book
                .Include(b => b.Author) // Ensure author data is available
                .Select(b => new
                {
                    b.ID,
                    BookDetails = b.Title + " - " + b.Author.LastName + " " + b.Author.FirstName
                }).ToList();

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookDetails");

            var memberList = _context.Member
                .Select(m => new
                {
                    m.ID,
                    MemberName = m.FirstName + " " + m.LastName
                }).ToList();

            ViewData["MemberID"] = new SelectList(memberList, "ID", "MemberName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
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

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
