using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrossOver.Service.BookData.Controllers
{
    public class BookDataController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var db = new CrossOverDBUnitOfWork();

            //var bookId=new ObjectId("59039c98d4160090c6ab1466");
            var allBooks =
                db.Books.Find(book => true).ToListAsync().Result;
            //bookCollection.find({ }).
            return Request.CreateResponse(HttpStatusCode.OK, allBooks);

        }
    }
}
