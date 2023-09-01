using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddStation
{
    public class AddStationCommandHandler: IRequestHandler<AddStationCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddStationCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddStationCommand command, CancellationToken cancellationToken)
        {
            Station station = new Station();
            station.StationName = command.StationName;

            _context.Station.Add(station);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
