using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_Lab2.Data;
using Cirlig_Bianca_Lab2.Models;

namespace Cirlig_Bianca_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Cirlig_Bianca_Lab2.Data.Cirlig_Bianca_Lab2Context _context;

        public IndexModel(Cirlig_Bianca_Lab2.Data.Cirlig_Bianca_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
