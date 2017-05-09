using CompanyName.DataLayer.Models.Models;

namespace CompanyName.BusinessLayer.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        User GetUserDetails(User user);

        bool CreateUser(User user);

        string GetUserId(string userName);
    }
}
