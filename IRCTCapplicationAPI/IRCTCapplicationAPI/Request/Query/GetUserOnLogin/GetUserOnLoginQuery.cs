using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetUserOnLogin
{
    public class GetUserOnLoginQuery : IRequest<List<ViewUserId>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
