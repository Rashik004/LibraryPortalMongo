using CrossOver.DataAccessLayer.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;

namespace CrossOver.Service.BookData.Controllers
{

    public class SearchController : ApiController
    {
        private static CrossOverDBUnitOfWork db = new CrossOverDBUnitOfWork();

        public HttpResponseMessage Get(string id)
        {
            var searchResult=db.Books
                .Find(book => book.Title.StartsWith(id) || book.Publisher.StartsWith(id))
                .ToListAsync().Result;
            return Request.CreateResponse(HttpStatusCode.OK, searchResult);
        }

        public HttpResponseMessage Get(int id)

        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
