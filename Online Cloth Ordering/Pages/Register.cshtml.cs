using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Online_Cloth_Ordering.Model;
using Online_Cloth_Ordering.ViewModel;

namespace Online_Cloth_Ordering.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Register Model { get; set; }
        private ISessionsRepro _sess;
        public UserManager<IdentityUser> userManager { get; private set; }
        public SignInManager<IdentityUser> signInManager { get; private set; }

        public RegisterModel(UserManager<IdentityUser> userManager ,  ISessionsRepro sess ,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _sess = sess;
        }
       
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Username,
                    Email = Model.Email,
                    PhoneNumber = Model.PhoneNumber

                };

                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                   await signInManager.SignInAsync(user, false);
                    Sessions add = new Sessions();
                    add.UserName = Model.Username;
                    _sess.Add(add);
                    return Redirect("Products");

                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Page();
        }
    }
}
