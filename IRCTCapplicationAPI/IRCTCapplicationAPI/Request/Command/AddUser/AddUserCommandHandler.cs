using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddUserCommandHandler(IrctcContext context) 

        {
            _context = context;
        }
        public async Task<bool> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            User user = new User(command.UserName, command.Password, command.Email, command.IdentityCardID, command.UserTypeID); 

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
