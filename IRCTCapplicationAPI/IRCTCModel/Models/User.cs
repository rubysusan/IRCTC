using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string IdentityCardID { get; set; }
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        
    }
}
