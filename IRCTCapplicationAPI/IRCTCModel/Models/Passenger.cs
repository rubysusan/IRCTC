using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Passenger
    {
        public int PassengerId { get;  }
        public string PassengerName { get; private set; }
        public int SeatId { get; private set; }
        public Seat Seat { get; set; }
        public int BookingId { get; private set; }
        public Booking Booking { get; set; }
        public bool HasArrived { get; private set; }
        public Passenger() { }
        public Passenger(string name,int seatId,int bookId,bool val)
        {
            PassengerName = name;
            SeatId = seatId;
            BookingId = bookId;
            HasArrived = val;
        }
        public void UpdatePassenger(bool val)
        {
            HasArrived = val;
        }

    }
}
