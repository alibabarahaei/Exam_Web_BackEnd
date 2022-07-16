using CodeYad_Blog.CoreLayer.Utilities;
using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Exam_Web.Pages.account
{


    [BindProperties]
    public class registerModel : PageModel
    {
        private readonly IUserService _userService;



        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        #endregion



        public registerModel(IUserService userService)
        {
            _userService = userService;
        }



        public void OnGet()
        {
        }





        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userService.RegisterUser(new RegisterUserDto()
            {
                UserName = UserName,
                Password = Password,
                Email = Email
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("../Login/Index");

        }
    }
}
