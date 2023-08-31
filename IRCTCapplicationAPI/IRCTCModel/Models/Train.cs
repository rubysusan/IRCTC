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
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ReachingTime { get; set; }
    }
}
