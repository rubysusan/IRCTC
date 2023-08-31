using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainStop
    {
        public int TrainStopId { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public int StopStationId { get; set; }
        public Station Station { get; set; }
        public DateTime ReachingTime { get; set; }
        public int StationCount { get; set; }
    }
}
