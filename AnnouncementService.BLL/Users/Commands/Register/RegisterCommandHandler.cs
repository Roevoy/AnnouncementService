using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AnnouncementService.BLL.Users.Commands    
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            await _userManager.AddToRoleAsync(user, "User");
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return Unit.Value;
        }
    }
}
