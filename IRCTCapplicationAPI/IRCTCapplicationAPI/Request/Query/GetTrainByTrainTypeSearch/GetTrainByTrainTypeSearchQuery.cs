using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetTrainByTrainTypeSearch
{
    public class GetTrainByTrainTypeSearchQuery:IRequest<List<ViewTrainByTrainTypeSearch>>
    {
        public string FromStationName { get; set; }
        public string ToStationName { get; set; }

        public DateTime Date { get; set; }
        public string CoachName { get; set; }
        public string TypeName { get; set; }
    }
}
