using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class User
    {
        public int UserId { get; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string IdentityCardID { get; private set; }
        public int UserTypeID { get; private set; }
        public UserType UserType { get; set; }
        public User()
        {
            
        }
        public User(string Name,string Pass,string Mail,string Card, int TypeId)
        {
            UserName = Name;
            Password=Pass; 
            Email = Mail; 
            IdentityCardID = Card;
            UserTypeID = TypeId;
            
        }
        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();

        public void UserUpdate(string Name, String Pass, String Mail, string Card, int TypeId)
        {
            UserName=Name;
            Password=Pass;
            Email=Mail;
            IdentityCardID = Card;
            UserTypeID = TypeId;
        }

    }
}
