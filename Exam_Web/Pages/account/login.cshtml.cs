using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Security.Claims;

namespace Exam_Web.Pages.account
{

    [BindProperties]
    public class loginModel : PageModel
    {
        private readonly IUserService _userService;

        public loginModel(IUserService userService)
        {
            _userService = userService;
        }



        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "یادآوری کلمه عبور")]
        public bool RememberMe { get; set; }

        public void OnGet()
        {
         
            var x=_userService.IsSignedIn(User);
            var c = User;
            if (x == null)
            {
                var zx = User;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (_userService.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                var result =await _userService.LoginUser(new LoginUserDto()
                {
                    UserName = UserName,
                    Password = Password,
                    RememberMe = RememberMe
                });

                if (result.Succeeded)
                {
                   

                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    
                }

                

                return RedirectToPage("../Index");

            }
            return RedirectToPage("../Index");
        }

        private DateTime GetExpireDateTime(bool isRememberMe)
            {
                return isRememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(1);
            }


    }



}
