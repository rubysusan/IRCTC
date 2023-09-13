using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Booking
    {
        public int BookingId { get; }
        public int TrainClassId { get; private set; }
        public TrainClass TrainClass { get; set; }
        public int FromStop { get; private set; }
        public TrainStop FromTrainStop { get; set; }
        public int ToStop { get; private set; }
        public TrainStop ToTrainStop { get; set; }
        public int Count { get; private set; }
        public double TotalCost { get; private set; }
        public int UserId { get; private set; }
        public User User { get; set; }
        public int BookingStatusId { get; private set; }
        public BookingStatus BookingStatus { get; set; }
        public Booking()
        {

        }
        public Booking(int trainClassId,int from,int to,int count,int cost,int userId,int statId)
        {
            TrainClassId = trainClassId;
            FromStop = from;
            ToStop = to;
            Count=count;
            TotalCost = cost;
            UserId = userId;
            BookingStatusId = statId;
        }
        public virtual IEnumerable<Passenger> Passengers { get; set; } = new List<Passenger>();
        public void BookingStatusUpdate(int statusId)
        {
            BookingStatusId=statusId;
        }
    }
}
