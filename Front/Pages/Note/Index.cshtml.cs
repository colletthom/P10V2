using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Front.Data;
using Front.VModel;

namespace Front.Pages.Note
{
    public class IndexModel : PageModel
    {
        private readonly Front.Data.ApplicationDbContext _context;

        public IndexModel(Front.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NoteVM> NoteVM { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.NoteVM != null)
            {
                NoteVM = await _context.NoteVM.ToListAsync();
            }
        }
    }
}
