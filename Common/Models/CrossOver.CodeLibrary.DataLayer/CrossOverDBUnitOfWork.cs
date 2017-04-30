using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;
using System.Web.Configuration;

namespace CrossOver.DataAccessLayer.DBModel
{
    public class DBUnitOfWork
    {
        public IMongoDatabase Database;
        public IMongoCollection<Book> Books;
        public IMongoCollection<User> Users; 

        public DBUnitOfWork()
        {
            //if (_database != null)
            //{
            //    return;
            //}
            //var kernel = new StandardKernel();
            string userName = WebConfigurationManager.AppSettings["MongoDBConectionString"];
            if (userName == null)
            {
                Console.WriteLine("BAAL");
            }
            var client=new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Crossover");
            Database = db;
            Books = db.GetCollection<Book>("Book");
            Users = db.GetCollection<User>("User");
        }
    }
}
