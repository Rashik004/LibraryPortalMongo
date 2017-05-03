using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Driver;

namespace CrossOver.DataAccessLayer.DbContext
{
    public class DbContext
    {
        public IMongoDatabase Database;
        public IMongoCollection<Book> Books;
        public IMongoCollection<User> Users; 

        public DbContext()
        {
            //if (_database != null)
            //{
            //    return;
            //}
            //var kernel = new StandardKernel();
            //string userName = WebConfigurationManager.AppSettings["MongoDBConectionString"];
            //if (userName == null)
            //{
            //    Console.WriteLine("BAAL");
            //}
            var client=new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Crossover");
            Database = db;
            Books = db.GetCollection<Book>("Book");
            Users = db.GetCollection<User>("User");
        }
    }
}
