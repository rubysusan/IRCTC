using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public int SeatTypeId { get; set; }
        public SeatType SeatType { get; set; }
        public int TrainClassId { get; set; }
        public TrainClass TrainClass { get; set; }
        public int FromStop { get; set; }
        public TrainStop FromTrainStop { get; set; }
        public int ToStop { get; set; }
        public TrainStop ToTrainStop { get; set; }
        public int Count { get; set; }
        public string Preference { get; set; }
        public double TotalCost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
