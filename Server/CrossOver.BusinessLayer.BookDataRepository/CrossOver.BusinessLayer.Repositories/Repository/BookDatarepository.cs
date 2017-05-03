using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOver.BusinessLayer.Repositories.Interfaces;
using CrossOver.DataAccessLayer.DbContext;
using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrossOver.BusinessLayer.Repositories.Repository
{
    public class BookDatarepository: IBookDatarepository
    {
        private readonly DbContext _db;
        public BookDatarepository()
        {
            _db = new DbContext();
        }

        public IList<Book> GetAllBooks()
        {
            return _db.Books
                .Find(book => true)
                .SortBy(b => b.Title)
                .ToListAsync()
                .Result;
        }
       
    }
}
