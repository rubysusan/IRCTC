using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetTrainBySearch
{
    public class GetTrainBySearchQuery:IRequest<List<ViewTrainBySearch>>
    {
        public int FromStationId { get; set; }
        public int ToStationId { get; set;}

        public DateTime Date { get; set; }
        public int CoachId { get; set; }

    }
}
