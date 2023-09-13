using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Seat
    {
        public int SeatId { get; }
        public string SeatNumber { get; private set; }
        public int SeatTypeId { get; private set; }
        public SeatType SeatType { get; set; }
        public int TrainClassId { get; private set; }
        public TrainClass TrainClass { get; set; }
        public int SeatStatusId { get; private set; }
        public SeatStatus SeatStatus { get; set; }
        public Seat()
        {
            
        }

        public Seat(string Num, int SeatType,int TrainClass,int SeatStatus)
        {
            SeatNumber = Num;
            SeatTypeId = SeatType;
            TrainClassId = TrainClass;
            SeatStatusId = SeatStatus;
        }
        public void SeatUpdate(int seatStatusId)
        {
           SeatStatusId=seatStatusId;
        }
        public virtual Passenger Passenger { get; set; } 
    }
}
