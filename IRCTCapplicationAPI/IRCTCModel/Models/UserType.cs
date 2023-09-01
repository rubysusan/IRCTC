using UserTypeEnum = IRCTCModel.Enums.UserType;

namespace IRCTCModel.Models
{
    public class UserType
    {
        public UserType(UserTypeEnum userTypeId)
        {
            UserTypeId = (byte)userTypeId;
            TypeName = userTypeId.ToString();
        }

        public int UserTypeId { get; set; }
        public string TypeName { get; set; }

    }
}