using CodeYad_Blog.CoreLayer.Utilities;
using Exam_Web.CoreLayer.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Exam_Web.CoreLayer.Services.Users
{
    public interface IUserService
    {
//        OperationResult EditUser(EditUserDto command);
        Task<IdentityResult> RegisterUser(RegisterUserDto RegisterDto);

        bool IsSignedIn(ClaimsPrincipal user);
        Task<SignInResult> LoginUser(LoginUserDto LoginDto);




    }
}
