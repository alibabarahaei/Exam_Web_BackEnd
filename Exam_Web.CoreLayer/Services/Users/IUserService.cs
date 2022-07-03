using CodeYad_Blog.CoreLayer.Utilities;
using Exam_Web.CoreLayer.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.CoreLayer.Services.Users
{
    public interface IUserService
    {
//        OperationResult EditUser(EditUserDto command);
        OperationResult RegisterUser(RegisterUserDto RegisterDto);
//        UserDto LoginUser(LoginUserDto command);




    }
}
