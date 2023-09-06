using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Station
    {
        public int StationId { get; set; }
        public string StationName { get; set; }


        public virtual IEnumerable<Train> FromTrains { get; set; } = new List<Train>();
        public virtual IEnumerable<Train> ToTrains { get; set; } = new List<Train>();
        public virtual IEnumerable<TrainStop> TrainStops { get; set; } = new List<TrainStop>();
    }
}
