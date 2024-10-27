using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cirlig_Bianca_lab2.Data;
using Cirlig_Bianca_lab2.Models;

namespace Cirlig_Bianca_lab2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context _context;

        public CreateModel(Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
