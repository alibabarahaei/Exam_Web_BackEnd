using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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

            
            List<Claim> claims = new List<Claim>()
            {
               new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
               new Claim(ClaimTypes.Email,user.Email),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                AllowRefresh=true,
                IsPersistent = true,
                ExpiresUtc= GetExpireDateTime(true)
            };
            HttpContext.SignInAsync(claimPrincipal, properties);
            



            return RedirectToPage("../Index");

        }


        private DateTime GetExpireDateTime(bool isRememberMe)
        {
            return isRememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(1);
        }


    }



}
