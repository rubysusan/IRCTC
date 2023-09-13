using MediatR;

namespace IRCTCapplicationAPI.Request.Command.Cancellation
{
    public class CancellationCommand : IRequest<bool>
    {
        public int BookingId { get; set; }
    }
}
