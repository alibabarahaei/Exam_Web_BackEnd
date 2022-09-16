using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Exam_Web.Pages.account
{


    [BindProperties]
    public class registerModel : PageModel
    {
        private readonly IUserService _userService;



        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 6)]
        [PageRemote(PageHandler = "IsUserNameInUse", HttpMethod = "Get")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        [PageRemote(PageHandler = "IsEmailInUse", HttpMethod = "Get")]
        [StringLength(40, ErrorMessage = "طول {0} باید  حداکثر  {1} کاراکتر باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(8, ErrorMessage = "{0} باید بیشتر از 7 کاراکتر باشد")]
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 8)]
        public string Password { get; set; }





        



        #endregion



        public registerModel(IUserService userService)
        {
            _userService = userService;
        }



        public void OnGet()
        {
        }





        public async Task<IActionResult> OnPost()
        {


            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = await _userService.RegisterUser(new RegisterUserDto()
            {
                UserName = UserName,
                Password = Password,
                Email = Email
            });



            if (!result.Succeeded)
            {
                var error_username = false;
                var error_password = false;
                var error_email = false;
                foreach (var error in result.Errors)
                {

                    if (error.Code.Contains("Password") && error_password != true)
                    {
                        error_password = true;
                        ModelState.AddModelError("Password", error.Description);
                    }
                    else if (error.Code.Contains("UserName") && error_username != true)
                    {
                        error_username = true;
                        ModelState.AddModelError("UserName", error.Description);
                    }
                    else if (error.Code.Contains("Email") && error_email != true)
                    {
                        ModelState.AddModelError("Email", error.Description);
                        error_email = true;
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", error.Description);
                        error_username = true;
                    }
                    return Page();

                }



                return Page();
            }

            return RedirectToPage("../Index");

        }




        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnGetIsEmailInUse(string email)
        {
            var user = await _userService.IsEmailInUse(email);
            if (user == null) return new JsonResult(true);
            return new JsonResult("ایمیل وارد شده از قبل موجود است");
        }


        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnGetIsUserNameInUse(string userName)
        {
            var user = await _userService.IsUserNameInUse(userName);
            if (user == null)
                return new JsonResult(true);
            return new JsonResult("نام کاربری وارد شده توسط شخص دیگری انتخاب شده است");
        }





    }


}
