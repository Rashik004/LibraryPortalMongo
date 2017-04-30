using CrossOver.DataAccessLayer.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossOver.BusinessLayer.Repositories.Interfaces;
using MongoDB.Driver;

namespace CrossOver.Service.BookData.Controllers
{

    public class SearchController : ApiController
    {
        private static DBUnitOfWork db = new DBUnitOfWork();
        private IBookDatarepository _bookDatarepository;

        public SearchController(IBookDatarepository bookDatarepository)
        {
            _bookDatarepository = bookDatarepository;
        }

        public HttpResponseMessage Get(string id)
        {
            var searchResult = _bookDatarepository.SearchBook(id);
            return Request.CreateResponse(HttpStatusCode.OK, searchResult);
        }

        //public HttpResponseMessage Get(int id)

        //{
        //    return Request.CreateResponse(HttpStatusCode.NotFound);
        //}
    }
}
