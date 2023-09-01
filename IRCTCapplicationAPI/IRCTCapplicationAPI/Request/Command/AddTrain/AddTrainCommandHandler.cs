using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrain
{
    public class AddTrainCommandHandler : IRequestHandler<AddTrainCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddTrainCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddTrainCommand command, CancellationToken cancellationToken)
        {
            Train train = new Train();
            train.TrainName = command.TrainName;
            train.FromStationId = command.FromStationId;
            train.ToStationId = command.ToStationId;
            train.Date = command.Date;
            train.DepartureTime = command.DepartureTime;
            train.ReachingTime = command.ReachingTime;
            train.TrainTypeID = command.TrainTypeID;

            _context.Train.Add(train);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
