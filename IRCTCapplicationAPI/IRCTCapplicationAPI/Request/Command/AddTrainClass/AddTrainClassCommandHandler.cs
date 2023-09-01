using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrainClass
{
    public class AddTrainClassCommandHandler : IRequestHandler<AddTrainClassCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddTrainClassCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddTrainClassCommand command, CancellationToken cancellationToken)
        {
            TrainClass trainClass = new TrainClass();
            trainClass.TrainId = command.TrainId;
            trainClass.ClassId = command.ClassId;
            _context.TrainClass.Add(trainClass);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
