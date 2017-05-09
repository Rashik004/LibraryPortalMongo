using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyName.DataLayer.Models.Models;

namespace CompanyName.BusinessLayer.Repositories.Interfaces
{
    public interface IManageOrderRepository
    {
        Task<User> PlaceOrder(string userId, string bookId);
        Task<User> DeleteOrder(string userId, string bookId);
        IList<Book> ListOrders(string userId);
    }
}
