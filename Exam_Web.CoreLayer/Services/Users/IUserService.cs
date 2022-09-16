using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Exam_Web.CoreLayer.Services.Users
{
    public interface IUserService
    {
        
        //        OperationResult EditUser(EditUserDto command);
        Task<IdentityResult> RegisterUser(RegisterUserDto RegisterDto);

        bool IsSignedIn(ClaimsPrincipal user);
        Task<SignInResult> LoginUser(LoginUserDto LoginDto);
        public Task<string> GetIdByUserName(string userName);
        Task<UserIdentity> IsUserNameInUse(string userName);
        Task<UserIdentity> IsEmailInUse(string email);
        Task<UserIdentity> FindByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(UserIdentity user);
        Task<IdentityResult> AddLoginAsync(UserIdentity user, UserLoginInfo info);
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<SignInResult> ExternalLoginSignInAsync(string LoginProvider,
            string ProviderKey, bool isPersistent, bool bypassTwoFactor);
        Task SignInAsync(UserIdentity user, bool isPersistent);
    }
}
