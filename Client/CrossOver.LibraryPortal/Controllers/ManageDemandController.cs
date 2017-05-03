using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossOver.DataAccessLayer.DBModel;
using MongoDB.Bson;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace CrossOver.LibraryPortal.Controllers
{
    public class ManageDemandController : Controller
    {
        private readonly string _baseUrl;
        // GET: ManageDemand
        private readonly DBUnitOfWork _db;
        private readonly string _placeDemandUriFormat = "placedemand/user/{0}/book/{1}";
        private readonly string _listDemandUriFormat = "listdemand/user/{0}";
        private readonly string _deleteDemandUriFormat = "deletedemand/user/{0}/book/{1}";
        public ManageDemandController(/*DBUnitOfWork db*/)
        {
            _db = new DBUnitOfWork();
            _baseUrl = "http://localhost:8085/";
        }
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var client = ClientProcessor();
            var result = await client.GetAsync(String.Format(_listDemandUriFormat, Session["userId"]));
            if (result.IsSuccessStatusCode)
            {
                var bookresponse = result.Content.ReadAsStringAsync().Result;
                var bookList = JsonConvert.DeserializeObject<List<Book>>(bookresponse);
                return View(bookList);
            }
            return View(new List<Book>());
        }

        public async System.Threading.Tasks.Task<ActionResult> PlaceDemand(string userId, string bookId)
        {

            var client = ClientProcessor();
            var result = await client.PostAsync(String.Format(_placeDemandUriFormat, userId, bookId), null);
            if (result.IsSuccessStatusCode)
            {
                System.Console.WriteLine("asd");
            }
            return RedirectToAction("Index", "BookList");
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteDemand(string userId, string bookId)
        {

            var client = ClientProcessor();
            var result = await client.DeleteAsync(String.Format(_deleteDemandUriFormat, userId, bookId));
            if (result.IsSuccessStatusCode)
            {
                System.Console.WriteLine("asd");
            }
            return RedirectToAction("Index");
        }

        public HttpClient ClientProcessor()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}