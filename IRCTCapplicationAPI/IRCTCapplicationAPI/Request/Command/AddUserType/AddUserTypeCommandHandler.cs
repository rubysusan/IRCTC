using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.AddUser;
using IRCTCModel.Models;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IRCTCapplicationAPI.Request.Command.AddUserType
{
    public class AddUserTypeCommandHandler : IRequestHandler<AddUserTypeCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddUserTypeCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddUserTypeCommand command, CancellationToken cancellationToken)
        {
            UserType userType = new UserType();
            userType.TypeName = command.TypeName;

            _context.UserType.Add(userType);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
