using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrain
{
    public class AddTrainCommand:IRequest<bool>
    {
        public string TrainName { get; set; }

        public int FromStationId { get; set; }
        

        public int ToStationId { get; set; }
       
        public int TrainTypeID { get; set; }
        
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ReachingTime { get; set; }
    }
}
