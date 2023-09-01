using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddStation
{
    public class AddStationCommand:IRequest<bool>
    {
        public string StationName { get; set; }
    }
}
