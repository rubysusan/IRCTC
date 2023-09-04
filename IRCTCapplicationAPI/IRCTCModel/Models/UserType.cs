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

        public int UserTypeId { get; set; }
        public string TypeName { get;  }

    }
}