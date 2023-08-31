using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.AddUser;
using IRCTCapplicationAPI.Request.Query.GetAllUser;
using IRCTCModel.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Request.Query.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler <GetAllUserQuery,List<User>>
    {
       
            private readonly IrctcContext _context;
            public GetAllUserQueryHandler(IrctcContext context)

            {
                _context = context;
            }
            public async Task<List<User>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
            {
                

            return _context.User.ToList();
        }
    }
    
}
