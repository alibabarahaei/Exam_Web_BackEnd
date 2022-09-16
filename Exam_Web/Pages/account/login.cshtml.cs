using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

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







        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }









        public async Task OnGet()
        {


            ReturnUrl = "%2F";
            ExternalLogins = (await _userService.GetExternalAuthenticationSchemesAsync()).ToList();
            

            ViewData["returnUrl"] = ReturnUrl;
            

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

        
        public IActionResult OnPostExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = "https://localhost:7271/account/login/?handler=ExternalLoginCallBack";



            var properties = _userService.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetExternalLoginCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");


            ReturnUrl = returnUrl;
                ExternalLogins = (await _userService.GetExternalAuthenticationSchemesAsync()).ToList();
            

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return Page();
            }

            var externalLoginInfo = await _userService.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return Page();
            }

            var signInResult = await _userService.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, true);

            if (signInResult.Succeeded)
            {
                return RedirectToPage("Login", "ExternalLoginCallBack");
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var user = await _userService.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email.Split('@')[0];
                    user = new UserIdentity()
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await _userService.CreateUserAsync(user);
                }

                await _userService.AddLoginAsync(user, externalLoginInfo);
                await _userService.SignInAsync(user, false);

                return Redirect(returnUrl);
            }

            return Page();
        }
    }



}
