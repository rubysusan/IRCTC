using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetTrainByTrainTypeSearch;
using IRCTCModel.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IRCTCapplicationAPI.Request.Query.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, List<ViewUser>>
    {
        private readonly IrctcContext _context;
        public GetUserByIdQueryHandler(IrctcContext context)
        {
            _context = context;
        }
        public async Task<List<ViewUser>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.Where(x => x.UserId == request.UserId).Select(x => new ViewUser
            {
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                IdCard = x.IdentityCardID,
                UserType=x.UserType.TypeName
            }
            ).ToListAsync();
        }
    }
}
