using System.Collections.Generic;
using CompanyName.DataLayer.Models.Models;

namespace CompanyName.BusinessLayer.Repositories.Interfaces
{
    public interface IBookDatarepository
    {
        IList<Book> GetAllBooks();
    }
}
