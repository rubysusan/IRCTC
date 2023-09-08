using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainStop
    {
        public int TrainStopId { get; }
        public int TrainId { get; private set; }
        public Train Train { get; set; }
        public int StopStationId { get; private set; }
        public Station Station { get; set; }
        public DateTime ReachingTime { get; private set; }
        public int StationCount { get; private set; }
        public TrainStop()
        {
            
        }
        public TrainStop(int Id,int StopId,DateTime Reaching,int Count)
        {
            TrainId = Id;
            StopStationId = StopId;
            ReachingTime = Reaching;
            StationCount = Count;
        }

        public virtual IEnumerable<Booking> FromBookings { get; set; } = new List<Booking>();
        public virtual IEnumerable<Booking> ToBookings { get; set; } = new List<Booking>();
    }
}
