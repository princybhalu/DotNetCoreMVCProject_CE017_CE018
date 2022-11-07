using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Online_Cloth_Ordering.ViewModel;
using Online_Cloth_Ordering.Model;

namespace Online_Cloth_Ordering.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }
        private ISessionsRepro _sess ;

        private readonly SignInManager<IdentityUser> signInManager;

        public LoginModel( SignInManager<IdentityUser> signInManager , ISessionsRepro sess )
        {
            this.signInManager = signInManager;
            _sess = sess;
        }

        public void OnGet()
        {
           // Session("Username") = "hi";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                var identityResult = await signInManager.PasswordSignInAsync(Model.Username ,
                    Model.Password, Model.RememberMe , false);
                if (identityResult.Succeeded)
                {

                    Sessions add = new Sessions();
                    add.UserName = Model.Username;
                    _sess.Add(add);
                  
                    return Redirect("Products");
                   
                }


                ModelState.AddModelError("", "Username or Password Incorrect");
                
            }
            //return RedirectToPage("Index");
           

           return Page();
        }
    }
}
