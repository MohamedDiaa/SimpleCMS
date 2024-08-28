using Microsoft.AspNetCore.Identity;

namespace SimpleCMS.Service
{
    public interface IRegisterUserService
    {
        public Task<IdentityResult?> Register(string email, string password);
    }
}
