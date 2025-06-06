using MediatR;

namespace AnnouncementService.BLL.Users.Queries
{
    public class LoginQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
