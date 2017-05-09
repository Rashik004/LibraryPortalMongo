using CompanyName.BusinessLayer.Repositories.Interfaces;
using CompanyName.DataAccessLayer.DbContext;
using CompanyName.DataLayer.Models.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CompanyName.BusinessLayer.Repositories.Repository
{
    public class AuthenticationRepository:IAuthenticationRepository
    {
        private readonly DbContext _db;

        public AuthenticationRepository()
        {
            _db=new DbContext();
        }

        public User GetUserDetails(User user)
        {
            var authenticatedUser = _db.Users
                .Find(u => u.Username == user.Username && u.Password == user.Password)
                .FirstOrDefaultAsync().Result;
            return authenticatedUser;
        }

        public bool CreateUser(User user)
        {
            if (GetUserId(user.Username) != null)
                return false;
            user.Id = ObjectId.GenerateNewId();
            user.Books=new ObjectId[0];
            _db.Users.InsertOne(user);
            return true;
        }

        public string GetUserId(string userName)
        {
            var user = _db.Users
                .Find(u => u.Username == userName)
                .FirstOrDefaultAsync().Result;
            return user?.Id.ToString();
        }
    }
}
