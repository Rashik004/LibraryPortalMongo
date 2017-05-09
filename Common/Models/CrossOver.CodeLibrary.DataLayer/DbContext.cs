using System.Web.Configuration;
using CompanyName.DataLayer.Models.Models;
using MongoDB.Driver;

namespace CompanyName.DataAccessLayer.DbContext
{
    public class DbContext
    {
        public IMongoDatabase Database;
        public IMongoCollection<Book> Books;
        public IMongoCollection<User> Users; 

        public DbContext()
        {
            var connectionString = WebConfigurationManager.AppSettings["MongoDBConectionString"];
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            var db = client.GetDatabase(mongoUrl.DatabaseName);
            Database = db;
            Books = db.GetCollection<Book>("Book");
            Users = db.GetCollection<User>("User");
        }
    }
}
