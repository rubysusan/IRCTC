using IRCTCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class BookingStatus
    {
        public int BookingStatusId { get; private set; }
        public string Status { get; }

        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        private BookingStatus()
        {
            Status = string.Empty;
        }
        public BookingStatus(BookingStatusEnum bookingStatusEnum)
        {
            BookingStatusId = (byte)bookingStatusEnum;
            Status = bookingStatusEnum.ToString();
        }
    }
}
