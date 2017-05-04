using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using CrossOver.DataAccessLayer.DBModel;
using Newtonsoft.Json;

namespace CrossOver.LibraryPortal.Controllers
{
    [Authorize]
    public class BookListController : Controller
    {
        // GET: BookList
        public async Task<ActionResult> Index()
        {
            var baseurl = WebConfigurationManager.AppSettings["BookDataSvcBase"];
            var bookList = new List<Book>();

            var client = ClientProcessor(baseurl);
            var res = await client.GetAsync("bookdata");
            if (res.IsSuccessStatusCode)
            {
                var bookresponse = res.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<Book>>(bookresponse);
            }
            client.Dispose();
            return View(bookList);
        }

        // GET: BookList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        

        public HttpClient ClientProcessor(string baseUri)
        {
            var client=new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress=new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home");
        }
    }
}
