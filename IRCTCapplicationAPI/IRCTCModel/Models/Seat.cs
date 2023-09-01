using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public int SeatTypeId { get; set; }
        public SeatType SeatType { get; set; }
        public int TrainClassId { get; set; }
        public TrainClass TrainClass { get; set; }
        public int SeatStatusId { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
