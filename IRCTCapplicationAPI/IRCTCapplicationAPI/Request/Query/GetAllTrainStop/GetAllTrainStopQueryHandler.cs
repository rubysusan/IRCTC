using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Query.GetAllStation;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllTrainStop
{
    public class GetAllTrainStopQueryHandler : IRequestHandler<GetAllTrainStopQuery, List<TrainStop>>
    {

        private readonly IrctcContext _context;
        public GetAllTrainStopQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<TrainStop>> Handle(GetAllTrainStopQuery query, CancellationToken cancellationToken)
        {


            return _context.TrainStop.ToList();
        }
    }
}
