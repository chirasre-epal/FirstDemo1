using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginRazor.Pages.LoginPages
{
    public class RegistrationModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public RegistrationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Login Login { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Login.AddAsync(Login);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
