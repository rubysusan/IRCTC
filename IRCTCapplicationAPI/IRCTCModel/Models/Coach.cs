using IRCTCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public double BaseCharge { get; set; }
        public Coach(CoachEnum coachEnum,double charge)
        {
            CoachId = (byte)coachEnum;
            CoachName = coachEnum.ToString();
            BaseCharge = charge;
        }
    }
}
