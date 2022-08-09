using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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


    }
}
