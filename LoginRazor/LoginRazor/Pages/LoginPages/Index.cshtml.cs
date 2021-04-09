using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoginRazor.Pages.LoginPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Login Login { get; set; }
        public IEnumerable<Login> Logs { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Logs = await _db.Login.ToListAsync();
            int res = 0;
            
             foreach (Login l in Logs)
             {
                    if (l.Id == Login.Id && l.Password == Login.Password)
                    {
                        res = 1;
                        break;
                    }
              }
              if (res == 1)
              {
                    TempData["msg"] = "You are welcome to Admin Section";
              }
              else
              {
                    TempData["msg"] = "Admin id or Password is wrong!!";
              }
            return Page();
            
        }
    }
}
