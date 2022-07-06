using CodeYad_Blog.CoreLayer.Utilities;
using Exam_Web.CoreLayer.DTOs.Users;
using Exam_Web.DataLayer.Context;
using Exam_Web.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {

        private readonly ExamContext _context;


        public UserService(ExamContext context)
        {
            _context=context;
        }

        public UserDto LoginUser(LoginUserDto LoginDto)
        {
            var passwordHashed = LoginDto.Password.EncodeToMd5();
            var user =_context.Users.FirstOrDefault(u=>u.UserName == LoginDto.UserName && u.Password== passwordHashed);

            if (user == null)
                return null;
            var userDto = new UserDto()
            {
                Name=user.Name,
                Family=user.Family,
                Email=user.Email,
                UserName=user.UserName,
                Password=user.Password,
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
    }
}
