using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.AddTrain;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrainStop
{
    public class AddTrainStopCommandHandler : IRequestHandler<AddTrainStopCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddTrainStopCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddTrainStopCommand command, CancellationToken cancellationToken)
        {
            TrainStop trainStop = new TrainStop();
            trainStop.TrainId = command.TrainId;
            trainStop.StopStationId = command.StopStationId;
            trainStop.ReachingTime = command.ReachingTime;
            trainStop.StationCount = command.StationCount;

            _context.TrainStop.Add(trainStop);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
