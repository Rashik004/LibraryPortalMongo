using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using CrossOver.DataAccessLayer.DBModel;
using Newtonsoft.Json;

namespace CrossOver.LibraryPortal.Controllers
{
    public class BookListController : Controller
    {
        // GET: BookList
        private readonly DBUnitOfWork _db;
        private readonly HttpClient _bookDataClient;

        public BookListController()
        {
            _db=new DBUnitOfWork();

            //_bookDataClient = new HttpClient() {BaseAddress = new Uri("http://localhost:8084/api/") };
            //_bookDataClient.DefaultRequestHeaders.Clear();
            //_bookDataClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            var Baseurl = "http://localhost:8084/api/";
            var bookList = new List<Book>();
            //using (var client = new HttpClient())
            {
                var client = ClientProcessor(Baseurl);
                HttpResponseMessage res = await client.GetAsync("bookdata");
                if (res.IsSuccessStatusCode)
                {
                    var bookresponse = res.Content.ReadAsStringAsync().Result;
                    bookList = JsonConvert.DeserializeObject<List<Book>>(bookresponse);
                }
                client.Dispose();
            }
            return View(bookList);
        }

        // GET: BookList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public HttpClient ClientProcessor(string baseUri)
        {
            var client=new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress=new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
