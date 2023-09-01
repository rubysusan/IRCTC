using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddTrainClass
{
    public class AddTrainClassCommand:IRequest<bool>
    {
        public int TrainId { get; set; }
        
        public int ClassId { get; set; }
        
    }
}
