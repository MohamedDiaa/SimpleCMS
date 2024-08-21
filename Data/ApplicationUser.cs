using Microsoft.AspNetCore.Identity;
using SimpleCMS.Model;

namespace SimpleCMS.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Menu> Menus { get; set; }
    }

}
