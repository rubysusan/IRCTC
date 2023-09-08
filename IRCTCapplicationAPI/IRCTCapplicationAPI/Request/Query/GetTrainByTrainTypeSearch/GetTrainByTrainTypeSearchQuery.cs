using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetTrainByTrainTypeSearch
{
    public class GetTrainByTrainTypeSearchQuery:IRequest<List<ViewTrainByTrainTypeSearch>>
    {
        public int FromStationId { get; set; }
        public int ToStationId { get; set; }

        public DateTime Date { get; set; }
        public int CoachId { get; set; }
        public int TypeId { get; set; }
    }
}
