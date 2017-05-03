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
    public class ManageOrderRepository : IManageOrderRepository
    {
        private readonly DbContext _db;

        public ManageOrderRepository()
        {
            _db = new DbContext();
        }

        public async Task<User> PlaceOrder(string userId, string bookId)
        {
            var users = _db.Users;

            var filter = Builders<User>.Filter.Eq("Id", ObjectId.Parse(userId));
            var update = Builders<User>.Update.Push("Books", ObjectId.Parse(bookId));
            var result = await users.FindOneAndUpdateAsync(filter, update);
            return result;
        }

        public async Task<User> DeleteOrder(string userId, string bookId)
        {
            var filter = Builders<User>.Filter.Eq("Id", ObjectId.Parse(userId));
            var update = Builders<User>.Update.Pull("Books", ObjectId.Parse(bookId));
            var result = await _db.Users.FindOneAndUpdateAsync(filter, update);
            return result;
        }

        public IList<Book> ListOrders(string userId)
        {
            var currentUser = _db.Users
                .Find(b => b.Id == ObjectId.Parse(userId))
                .FirstOrDefaultAsync()
                .Result;
            var queryResult = currentUser.Books.AsQueryable()
                .Join(
                    _db.Books.AsQueryable(),
                    id => id,
                    book => book.Id,
                    (id, book) => new { book }
                )
                .Select(qr => new Book
                {
                    Id = qr.book.Id,
                    Authors = qr.book.Authors,
                    Description = qr.book.Description,
                    Publisher = qr.book.Publisher,
                    Title = qr.book.Title
                }).ToList();

            return queryResult;
        }
    }
}
