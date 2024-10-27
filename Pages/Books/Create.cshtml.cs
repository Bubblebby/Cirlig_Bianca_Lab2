using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cirlig_Bianca_lab2.Data;
using Cirlig_Bianca_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cirlig_Bianca_lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context _context;

        public CreateModel(Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
