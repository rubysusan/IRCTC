using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainClass
    {
        public int TrainClassId { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public int ClassId { get; set; }
        public Coach Coach { get; set; }

        public virtual IEnumerable<Seat> Seats { get; set; } = new List<Seat>();
        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
