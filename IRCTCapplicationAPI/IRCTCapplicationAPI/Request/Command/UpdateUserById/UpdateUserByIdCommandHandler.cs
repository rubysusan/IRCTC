using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.AddUser;
using IRCTCModel.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Command.UpdateUserById
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, List<User>>
    {

        private readonly IrctcContext _context;
        public UpdateUserByIdCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<User>> Handle(UpdateUserByIdCommand command, CancellationToken cancellationToken)
        {
            var type = _context.UserType.Where(x => x.TypeName == command.TypeName).Select(x => x.UserTypeId).SingleOrDefault();
            _context.User.FirstOrDefault(x => x.UserId == command.Id).UserUpdate(command.UserName, command.Password, command.Email, command.identityCardID, type); ;
            
            
        

            await _context.SaveChangesAsync();
            return _context.User.ToList();
        }
    }
}
