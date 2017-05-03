using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOver.DataAccessLayer.DBModel;

namespace CrossOver.BusinessLayer.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        User GetUserDetails(User user);

        bool CreateUser(User user);

        string GetUserId(string userName);
    }
}
