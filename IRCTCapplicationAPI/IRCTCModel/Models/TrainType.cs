﻿using IRCTCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainType
    {
        public int TrainTypeID { get; private set; }
        public string TypeName { get;}
        private TrainType()
        {
            TypeName = string.Empty;
        }
        public TrainType(TrainTypeEnum trainTypeEnum)
        {
            TrainTypeID=(byte)trainTypeEnum;
            TypeName=trainTypeEnum.ToString();
            
        }
        public virtual IEnumerable<Train> Trains { get; set; } = new List<Train>();
    }
}
