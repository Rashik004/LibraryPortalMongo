using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOver.DataAccessLayer.DBModel;

namespace CrossOver.BusinessLayer.Repositories.Interfaces
{
    public interface IBookDatarepository
    {
        IList<Book> GetAllBooks();

        IList<Book> SearchBook(string searchString);
        void AddUser( /*User user*/);
    }
}
