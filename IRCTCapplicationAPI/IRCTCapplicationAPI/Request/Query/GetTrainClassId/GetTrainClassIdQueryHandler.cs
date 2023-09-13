using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetTrainClassId
{
    public class GetTrainClassIdQueryHandler : IRequestHandler<GetTrainClassIdQuery, List<ViewTrainClassId>>
    {
        private readonly IrctcContext _context;
        public GetTrainClassIdQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<ViewTrainClassId>> Handle(GetTrainClassIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.TrainClass.Where(x => x.ClassId == request.CoachId && x.TrainId == request.TrainId)
                .Select(x => new ViewTrainClassId
                {
                    TrainClassId = x.TrainClassId
                }).ToListAsync();
        }
    }
}
