using CrossOver.DataAccessLayer.DBModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossOver.BusinessLayer.Repositories.Interfaces;

namespace CrossOver.Service.BookData.Controllers
{

    public class SearchController : ApiController
    {
        private readonly IBookDatarepository _bookDatarepository;

        public SearchController(IBookDatarepository bookDatarepository)
        {
            _bookDatarepository = bookDatarepository;
        }

        public HttpResponseMessage Get(string id)
        {
            var searchResult = _bookDatarepository.SearchBook(id);
            _bookDatarepository.AddUser();
            return Request.CreateResponse(HttpStatusCode.OK, searchResult);

        }

    }
}
