using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exam_Web.Pages.Login
{




    [BindProperties]
    public class IndexModel : PageModel
    {

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
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



        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var user = _userService.LoginUser(new LoginUserDto()
            {
                UserName = UserName,
                Password = Password
            });


            if (user == null)
            {
 //               ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                  return Page();
            }

            return RedirectToPage("../Index");

        }
    }
}
