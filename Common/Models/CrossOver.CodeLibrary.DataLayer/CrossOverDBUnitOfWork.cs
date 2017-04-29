using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;

namespace CrossOver.DataAccessLayer.DBModel
{
    public class CrossOverDBUnitOfWork
    {
        public IMongoDatabase Database;
        public IMongoCollection<Book> Books;
        public IMongoCollection<User> Users; 

        public CrossOverDBUnitOfWork()
        {
            //if (_database != null)
            //{
            //    return;
            //}
            var client=new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Crossover");
            Database = db;
            Books = db.GetCollection<Book>("Book");
            Users = db.GetCollection<User>("User");
        }
    }
}
