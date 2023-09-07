using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetCharge
{
    public class GetChargeQuery: IRequest<List<ViewCharge>>
    {
        public int TrainId { get; set; }
        public string FromStation { get; set; } 
        public string ToStation { get; set; }
        public string CoachName { get; set; }
    }
}
