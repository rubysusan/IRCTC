using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetTrainByTrainTypeSearch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetUserOnLogin
{
    public class GetUserOnLoginQueryHandler : IRequestHandler<GetUserOnLoginQuery, List<ViewUserId>>
    {
        private readonly IrctcContext _context;
        public GetUserOnLoginQueryHandler(IrctcContext context)
        {
            _context = context;
        }
        public async Task<List<ViewUserId>> Handle(GetUserOnLoginQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.Where(x=>x.UserName==request.UserName && x.Password==request.Password)
                .Select(x=> new ViewUserId
                {
                    UserId=x.UserId,
                    UserTypeId=x.UserTypeID
                }).ToListAsync();   
        }
    }
}
