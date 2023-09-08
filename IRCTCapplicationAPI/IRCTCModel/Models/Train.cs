using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Train
    {
        public int TrainId { get; }
        public string TrainName { get; private set; }

        public int FromStationId { get; private set; }
        public Station FromStation { get; set; }

        public int ToStationId { get; private set; }
        public Station ToStation { get; set; }
        public int TrainTypeID { get; private set; }
        public TrainType TrainType { get; set; }
        public DateTime Date { get; private set; }
        public DateTime DepartureTime { get; private set; }

        public DateTime ReachingTime { get; private set; }

        public virtual IEnumerable<TrainStop> TrainStops { get; set; } = new List<TrainStop>();
        public virtual IEnumerable<TrainClass> TrainClasses { get; set; } = new List<TrainClass>();
        public Train()
        {
            
        }
        public Train(string Name,int From,int To, int Type,DateTime TrainDate,DateTime Depart,DateTime Reaching )
        {
            TrainName = Name;
            FromStationId = From;
            ToStationId = To;
            TrainTypeID = Type;
            Date=TrainDate;
            DepartureTime = Depart;
            ReachingTime = Reaching;
            
        }
    }
}
