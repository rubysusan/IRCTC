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
            Train train = new Train(command.TrainName, command.FromStationId, command.ToStationId,command.TrainTypeID, command.Date, command.DepartureTime, command.ReachingTime);
           
            _context.Train.Add(train);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
