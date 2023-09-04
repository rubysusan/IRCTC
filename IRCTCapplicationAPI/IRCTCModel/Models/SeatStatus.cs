using IRCTCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class SeatStatus
    {
        public int SeatStatusId { get; set; }
        public string Status { get; }
        private SeatStatus()
        {
            Status = string.Empty;
        }
        public SeatStatus(SeatStatusEnum seatStatusEnum)
        {
            SeatStatusId = (byte)seatStatusEnum;
            Status = seatStatusEnum.ToString();
        }
    }
}
