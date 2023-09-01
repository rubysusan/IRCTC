using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrainType
{
    public class AddTrainTypeCommand : IRequest<bool>
    {
        public string TypeName { get; set; }
    }
}
