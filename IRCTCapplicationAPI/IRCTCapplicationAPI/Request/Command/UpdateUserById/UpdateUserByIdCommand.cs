using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.UpdateUserById
{
    public class UpdateUserByIdCommand: IRequest<List<User>>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
= string.Empty;

        public string Email { get; set; }
        = string.Empty; 
        public string Password { get; set; }    
        = string.Empty;
        public string identityCardID { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;

    }
}
