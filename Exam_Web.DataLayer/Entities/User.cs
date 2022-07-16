using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.DataLayer.Entities
{
    public class User
    {
        [Required]
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public UserRole? Role { get; set; }
    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
