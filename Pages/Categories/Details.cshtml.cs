using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_lab2.Data;
using Cirlig_Bianca_lab2.Models;

namespace Cirlig_Bianca_lab2.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context _context;

        public DetailsModel(Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
