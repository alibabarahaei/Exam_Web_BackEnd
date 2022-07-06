using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }




    }
}
