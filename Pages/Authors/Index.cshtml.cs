using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_lab2.Data;
using Cirlig_Bianca_lab2.Models;

namespace Cirlig_Bianca_lab2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context _context;

        public IndexModel(Cirlig_Bianca_lab2.Data.Cirlig_Bianca_lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Authors.ToListAsync();
        }
    }
}
