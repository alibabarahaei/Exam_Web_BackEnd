using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 6)]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "یادآوری کلمه عبور")]
        public bool RememberMe { get; set; }

        public void OnGet()
        {
           
            var x = User;
        }

        public async Task<IActionResult> OnPost()
        {
            
                

            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(new LoginUserDto()
                {
                    UserName = UserName,
                    Password = Password,
                    RememberMe = RememberMe
                });

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("UserName", "اکانت شما تا اطلاع ثانوی قفل شده است");
                        return Page();
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "نام کاربری یا رمز عبور اشتباه هست");
                        return Page();
                    }
                   
                }
                else
                {
                    return RedirectToPage("../Index");
                }

            }
            else
            {
                return Page();
            }


            return RedirectToPage("../Index");
        }

        private DateTime GetExpireDateTime(bool isRememberMe)
        {
            return isRememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(1);
        }


    }



}
