using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Bson;
using System.Collections;
using MongoDB.Driver;

namespace CrossOver.LibraryPortal.Controllers
{
    public class ManageDemandController : Controller
    {
        // GET: ManageDemand
        private readonly DBUnitOfWork _db;
        public ManageDemandController(/*DBUnitOfWork db*/)
        {
            _db=new DBUnitOfWork();
        }
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> PlaceDemand(string userId, string bookId)
        {
            var users = _db.Users;
            try
            {
                var filter = Builders<User>.Filter.Eq("Id", ObjectId.Parse(userId));
                var update = Builders<User>.Update.Push("Books", ObjectId.Parse(bookId));
                var result = await users.FindOneAndUpdateAsync(filter, update);
                if (result != null)
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }
}