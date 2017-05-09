using System.Collections.Generic;
using CompanyName.BusinessLayer.Repositories.Interfaces;
using CompanyName.DataAccessLayer.DbContext;
using CompanyName.DataLayer.Models.Models;
using MongoDB.Driver;

namespace CompanyName.BusinessLayer.Repositories.Repository
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
