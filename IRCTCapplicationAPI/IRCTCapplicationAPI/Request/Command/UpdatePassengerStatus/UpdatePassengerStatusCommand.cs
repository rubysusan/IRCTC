using MediatR;

namespace IRCTCapplicationAPI.Request.Command.UpdatePassengerStatus
{
    public class UpdatePassengerStatusCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
