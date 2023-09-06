using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }

        public int FromStationId { get; set; }
        public Station FromStation { get; set; }

        public int ToStationId { get; set; }
        public Station ToStation { get; set; }
        public int TrainTypeID { get; set; }
        public TrainType TrainType { get; set; }
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ReachingTime { get; set; }

        public virtual IEnumerable<TrainStop> TrainStops { get; set; } = new List<TrainStop>();
        public virtual IEnumerable<TrainClass> TrainClasses { get; set; } = new List<TrainClass>();
    }
}
