using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainClass
    {
        public int TrainClassId { get;  }
        public int TrainId { get; private set; }
        public Train Train { get; set; }
        public int ClassId { get; private set; }
        public Coach Coach { get; set; }
        public TrainClass()
        {
            
        }
        public TrainClass(int Id,int CoachId)
        {
            TrainId = Id;
            ClassId = CoachId;
        }
        public virtual IEnumerable<Seat> Seats { get; set; } = new List<Seat>();
        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
