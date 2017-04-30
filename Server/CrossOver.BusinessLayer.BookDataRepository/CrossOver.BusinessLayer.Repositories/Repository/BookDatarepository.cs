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
    public class BookDatarepository: IBookDatarepository
    {
        private DBUnitOfWork _db;
        public BookDatarepository()
        {
            _db = new DBUnitOfWork();
        }
        public IList<Book> GetAllBooks()
        {
            return _db.Books
                .Find(book => true)
                .SortBy(b => b.Title)
                .Limit(13)
                .ToListAsync()
                .Result;
        }

        public IList<Book> SearchBook(string searchString)
        {
            return _db.Books
                .Find(book => book.Title.StartsWith(searchString) || book.Publisher.StartsWith(searchString))
                .ToListAsync().Result;
        }
    }
}
