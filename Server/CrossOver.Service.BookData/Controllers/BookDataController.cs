using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossOver.BusinessLayer.Repositories.Interfaces;
using CrossOver.BusinessLayer.Repositories.Repository;
using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrossOver.Service.BookData.Controllers
{
    public class BookDataController : ApiController
    {
        private static DBUnitOfWork db = new DBUnitOfWork();
        private IBookDatarepository _bookDatarepository;

        public BookDataController(/*IBookDatarepository bookDatarepository*/)
        {
            //_bookDatarepository = bookDatarepository;
        }
        public HttpResponseMessage Get()
        {

            var allBooks = db.Books
                .Find(book => true)
                .SortBy(b => b.Title)
                .Limit(13)
                .ToListAsync()
                .Result;
            //var allBooks = _bookDatarepository.GetAllBooks();
            return Request.CreateResponse(HttpStatusCode.OK, allBooks);

        }

        //public HttpResponseMessage Get(int id)
        //{
        //    var db = new CrossOverDBUnitOfWork();
        //    var objectId=new  ObjectId();
        //    objectId=ObjectId.Parse();
        //    //var intendedBook = db.Books.Find(book => book.Id == id).ToListAsync().Result;
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }
}
