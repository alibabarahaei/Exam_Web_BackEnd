using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.DataLayer.Context;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Exam_Web.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {

        private readonly ExamContext _context;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;

        public UserService(ExamContext context, UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public bool IsSignedIn(ClaimsPrincipal user)
        {

            return _signInManager.IsSignedIn(user);
        }

        public async Task<SignInResult> LoginUser(LoginUserDto LoginDto)
        {
            var result =
                await _signInManager.PasswordSignInAsync(LoginDto.UserName, LoginDto.Password, LoginDto.RememberMe,
                    true);
            return result;
        }

        public async Task<UserIdentity> IsUserNameInUse(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<UserIdentity> IsEmailInUse(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<UserIdentity> FindByEmailAsync(string email)
        {
           return await _userManager.FindByNameAsync(email);
        }

        public async Task<IdentityResult> CreateUserAsync(UserIdentity user)
        {
            return await _userManager.CreateAsync(user);
        }

        public async Task<IdentityResult> AddLoginAsync(UserIdentity user,UserLoginInfo info)
        {
            return await _userManager.AddLoginAsync(user, info);
        }

        public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            return await _signInManager.GetExternalAuthenticationSchemesAsync();
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

       

        public async Task<IdentityResult> RegisterUser(RegisterUserDto RegisterDto)
        {

            var user = new UserIdentity()
            {
                UserName = RegisterDto.UserName,
                Email = RegisterDto.Email
            };

            var result = await _userManager.CreateAsync(user, RegisterDto.Password);
            return result;
        }

        public async Task<string> GetIdByUserName(string userName)
        {

            var x = await _userManager.FindByNameAsync(userName);
            return x.Id;

        }

        public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            return await _signInManager.GetExternalLoginInfoAsync();
        }

        public async Task<SignInResult> ExternalLoginSignInAsync(string LoginProvider, string ProviderKey, bool isPersistent, bool bypassTwoFactor)
        {
            return await _signInManager.ExternalLoginSignInAsync(LoginProvider,
                ProviderKey, isPersistent, bypassTwoFactor);
        }

        public async Task SignInAsync(UserIdentity user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }
    }

















    /*
    public UserDto LoginUser(LoginUserDto LoginDto)
    {
        
    }*/








































    /*
    public UserDto LoginUser(LoginUserDto LoginDto)
    {
        var passwordHashed = LoginDto.Password.EncodeToMd5();
        var user =_context.Users.FirstOrDefault(u=>u.UserName == LoginDto.UserName && u.Password== passwordHashed);

        if (user == null)
            return null;
        var userDto = new UserDto()
        {
            FirstName=user.FirstName,
            LastName=user.LastName,
            Email=user.Email,
            UserName=user.UserName,
            Password=user.Password,
            Role=user.Role,
        };
        return userDto;
    }

    public OperationResult RegisterUser(RegisterUserDto RegisterDto)
    {
        var isUserNameExist=_context.Users.Any(u => u.UserName == RegisterDto.UserName);
        if (isUserNameExist)
            return OperationResult.Error("نام کاربری تکراری است");
        var PasswordHash = RegisterDto.Password.EncodeToMd5();
        _context.Users.Add(new User()
        {
            UserName = RegisterDto.UserName,
            Password = PasswordHash,
            Email = RegisterDto.Email,
        });
        _context.SaveChanges();
        return OperationResult.Success();
    }

    */
}

