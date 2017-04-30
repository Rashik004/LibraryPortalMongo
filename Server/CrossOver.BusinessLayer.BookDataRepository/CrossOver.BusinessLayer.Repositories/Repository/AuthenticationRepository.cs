using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOver.BusinessLayer.Repositories.Interfaces;
using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Driver;

namespace CrossOver.BusinessLayer.Repositories.Repository
{
    public class AuthenticationRepository:IAuthenticationRepository
    {
        private readonly DBUnitOfWork _db;

        public AuthenticationRepository()
        {
            _db=new DBUnitOfWork();
        }

        public User GetUserDetails(User user)
        {
            var authenticatedUser = _db.Users
                .Find(u => u.Username == user.Username && u.Password == user.Password)
                .FirstOrDefaultAsync().Result;
            return authenticatedUser;
        }
    }
}
