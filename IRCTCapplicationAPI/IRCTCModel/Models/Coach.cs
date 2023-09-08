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
        public int CoachId { get; private set; }
        public string CoachName { get; }
        public double BaseCharge { get; private set; }

        public virtual IEnumerable<TrainClass> TrainClasses { get; set; } = new List<TrainClass>();
        private Coach() {
            CoachName = string.Empty;
        }
        public Coach(CoachEnum coachEnum,double charge)
        {
            CoachId = (byte)coachEnum;
            CoachName = coachEnum.ToString();
            BaseCharge = charge;
        }
    }
}
