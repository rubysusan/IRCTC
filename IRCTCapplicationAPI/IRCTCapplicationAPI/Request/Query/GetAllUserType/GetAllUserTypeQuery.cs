using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllUserType
{
    public class GetAllUserTypeQuery:IRequest<List<UserType>>
    {
    }
}
