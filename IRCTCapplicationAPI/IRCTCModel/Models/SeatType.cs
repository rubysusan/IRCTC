using IRCTCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class SeatType
    {
        public int SeatTypeId { get; set; }
        public string TypeName { get; set; }
        public virtual IEnumerable<Seat> Seats { get; set; } = new List<Seat>();
        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        private SeatType()
        {
            TypeName = string.Empty;
        }
        public SeatType(SeatTypeEnum seatTypeEnum)
        {
            SeatTypeId=(byte)seatTypeEnum;
            TypeName=seatTypeEnum.ToString();
        }
    }
}
