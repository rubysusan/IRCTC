using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrainStop
{
    public class AddTrainStopCommand : IRequest<bool>
    {
        public int TrainId { get; set; }
        public int StopStationId { get; set; }
        public DateTime ReachingTime { get; set; }
        public int StationCount { get; set; }
    }
}
