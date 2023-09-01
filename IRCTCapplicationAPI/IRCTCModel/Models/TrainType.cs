using IRCTCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainType
    {
        public int TrainTypeID { get; set; }
        public string TypeName { get; set; }
        public TrainType(TrainTypeEnum trainTypeEnum)
        {
            TrainTypeID=(byte)trainTypeEnum;
            TypeName=trainTypeEnum.ToString();
            
        }
    }
}
