﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Valasztasok.Models;

namespace Valasztasok.Pages
{
    public class JeloltListaModel : PageModel
    {
        private readonly Valasztasok.Models.ValasztasDbContext _context;

        public JeloltListaModel(Valasztasok.Models.ValasztasDbContext context)
        {
            _context = context;
        }

        public IList<Jelolt> Jelolt { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Jelolt = await _context.Jelolt.ToListAsync();
        }
    }
}
