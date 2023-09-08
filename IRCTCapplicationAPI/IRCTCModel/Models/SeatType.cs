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
        public int SeatTypeId { get; private set; }
        public string TypeName { get; }
        private SeatType()
        {
            TypeName = string.Empty;
        }
        public SeatType(SeatTypeEnum seatTypeEnum)
        {
            SeatTypeId=(byte)seatTypeEnum;
            TypeName=seatTypeEnum.ToString();
        }

        public virtual IEnumerable<Seat> Seats { get; set; } = new List<Seat>();
    }
}
