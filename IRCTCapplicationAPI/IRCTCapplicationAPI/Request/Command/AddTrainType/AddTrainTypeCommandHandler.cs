using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrainType
{
    public class AddTrainTypeCommandHandler : IRequestHandler<AddTrainTypeCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddTrainTypeCommandHandler(IrctcContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddTrainTypeCommand command, CancellationToken cancellationToken)
        {
           TrainType trainType=new TrainType();
            trainType.TypeName=command.TypeName;
            _context.TrainType.Add(trainType);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
