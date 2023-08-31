using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddUserType
{
    public class AddUserTypeCommand: IRequest<bool>
    {
        public string TypeName { get; set; }
    }
}
