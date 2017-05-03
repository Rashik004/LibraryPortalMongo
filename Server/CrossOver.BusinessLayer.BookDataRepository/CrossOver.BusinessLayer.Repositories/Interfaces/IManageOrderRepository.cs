using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOver.DataAccessLayer.DBModel;

namespace CrossOver.BusinessLayer.Repositories.Interfaces
{
    public interface IManageOrderRepository
    {
        Task<User> PlaceOrder(string userId, string bookId);
        Task<User> DeleteOrder(string userId, string bookId);
        IList<Book> ListOrders(string userId);
    }
}
