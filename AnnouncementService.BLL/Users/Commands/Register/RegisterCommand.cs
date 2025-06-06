using MediatR;

namespace AnnouncementService.BLL.Users.Commands
{
    public class RegisterCommand : IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RegisterCommand(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
