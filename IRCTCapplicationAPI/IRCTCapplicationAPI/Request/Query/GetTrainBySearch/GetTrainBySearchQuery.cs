using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetTrainBySearch
{
    public class GetTrainBySearchQuery:IRequest<List<ViewTrainBySearch>>
    {
        public string FromStationName { get; set; }
        public string ToStationName { get; set;}

        public DateTime Date { get; set; }
        public string CoachName { get; set; }

    }
}
