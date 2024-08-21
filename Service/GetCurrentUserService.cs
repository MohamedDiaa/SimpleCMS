using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data;

namespace SimpleCMS.Service
{
    public class GetCurrentUserService : IGetCurrentUserService
    {
 
        public async Task<ApplicationUser> GetCurrentUserAsync(AuthenticationStateProvider GetAuthenticationStateAsync, ApplicationDbContext dbContext)
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var authuser = authstate.User;
            var Name = authuser.Identity.Name;

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == Name);

            return user;
        }
    }
}
