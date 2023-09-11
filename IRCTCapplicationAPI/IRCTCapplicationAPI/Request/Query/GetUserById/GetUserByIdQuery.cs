using IRCTCapplicationAPI.DTO;
using IRCTCModel.Models;
using MediatR;
using System.Diagnostics.Contracts;

namespace IRCTCapplicationAPI.Request.Query.GetUserById
{
    public class GetUserByIdQuery: IRequest<List<ViewUser>>
    {
        public int UserId { get; set; }
    }
}
