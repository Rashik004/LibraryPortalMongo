using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossOver.BusinessLayer.Repositories.Interfaces;

namespace CrossOver.Service.BookData.Controllers
{
    public class BookDataController : ApiController
    {
        private readonly IBookDatarepository _bookDatarepository;

        public BookDataController(IBookDatarepository bookDatarepository)
        {
            _bookDatarepository = bookDatarepository;
        }
        public HttpResponseMessage Get()
        {
            var allBooks = _bookDatarepository.GetAllBooks();
            return Request.CreateResponse(HttpStatusCode.OK, allBooks);
        }

    }
}
