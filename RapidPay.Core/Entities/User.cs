using RapidPay.Core.Dtos;

namespace RapidPay.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public UserDto ToUserDto() => new()
        {
            Id = Id,
            Username = Username,
            Password = Password,
        };
    }
}
