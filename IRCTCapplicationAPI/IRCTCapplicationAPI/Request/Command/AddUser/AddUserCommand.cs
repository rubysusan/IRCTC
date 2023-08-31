using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddUser
{
    public class AddUserCommand:IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string IdentityCardID { get; set; }
        public int UserTypeID { get; set; }
    }
}
