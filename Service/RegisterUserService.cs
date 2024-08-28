using Bogus;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SimpleCMS.Data;
using Microsoft.AspNetCore.Components.Authorization;

namespace SimpleCMS.Service
{
    public class RegisterUserService: IRegisterUserService
    {
        private readonly IUserStore<ApplicationUser> UserStore;
        private readonly UserManager<ApplicationUser> UserManager;

        public RegisterUserService(IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
            this.UserStore = userStore;
        }

        public async Task<IdentityResult?> Register(string email, string password) {

            var user = new ApplicationUser();
            
            await UserStore.SetUserNameAsync(user, email, CancellationToken.None);

            var emailStore = (IUserEmailStore<ApplicationUser>)UserStore;
            await emailStore.SetEmailAsync(user, email, CancellationToken.None);
            user.EmailConfirmed = true;

            return await UserManager.CreateAsync(user, password);
        }
    }
}
