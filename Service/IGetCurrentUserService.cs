using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using SimpleCMS.Data;

namespace SimpleCMS.Service
{
    public interface IGetCurrentUserService
    {

        public  Task<ApplicationUser> GetCurrentUserAsync();
      }
}
