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
