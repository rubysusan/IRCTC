using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Query.GetAllUserType;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllUserType
{
    public class GetAllUserTypeQueryHandler : IRequestHandler<GetAllUserTypeQuery, List<UserType>>
    {

        private readonly IrctcContext _context;
        public GetAllUserTypeQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<UserType>> Handle(GetAllUserTypeQuery query, CancellationToken cancellationToken)
        {


            return _context.UserType.ToList();
        }
    }
}
