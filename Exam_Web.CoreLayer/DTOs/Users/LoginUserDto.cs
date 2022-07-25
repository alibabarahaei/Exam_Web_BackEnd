namespace Exam_Web.CoreLayer.DTOs.Users
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
