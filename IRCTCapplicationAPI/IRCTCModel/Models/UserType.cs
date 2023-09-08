using  IRCTCModel.Enums;

namespace IRCTCModel.Models
{
    public class UserType

    {
        private UserType()
        {
            TypeName = string.Empty;
        }
        public UserType(UserTypeEnum userTypeId)
        {
            UserTypeId = (byte)userTypeId;
            TypeName = userTypeId.ToString();
        }
        public virtual IEnumerable<User> Users { get; set; } = new List<User>();
        public int UserTypeId { get; private set; }
        public string TypeName { get;  }

    }
}