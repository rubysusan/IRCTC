using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }

        public int FromStationID { get; set; }
        public Station Station { get; set; }

        public int ToStationID { get; set; }
        public Station Station { get; set; }
        public string Date { get; set; }
        public string DepartureTime { get; set; }

        public string ReachingTime { get; set; }
    }
}
