using Microsoft.AspNetCore.Identity;

namespace WebAppAsset.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; }=string.Empty;
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }
        public UserProfileType UserType { get; set; }
    }
}
