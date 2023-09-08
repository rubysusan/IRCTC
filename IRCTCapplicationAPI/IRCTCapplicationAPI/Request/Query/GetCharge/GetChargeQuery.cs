using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetCharge
{
    public class GetChargeQuery: IRequest<List<ViewCharge>>
    {
        public int TrainId { get; set; }
        public int FromStationId { get; set; } 
        public int ToStationId { get; set; }
        public int CoachId { get; set; }
    }
}
