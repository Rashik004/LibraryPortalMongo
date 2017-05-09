using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using CompanyName.BusinessLayer.Repositories.Interfaces;
using CompanyName.BusinessLayer.Repositories.Repository;
using CompanyName.DataLayer.Models.Models;
using Microsoft.AspNet.Identity;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace CrossOver.LibraryPortal.Controllers
{
    [Authorize]
    public class ManageDemandController : Controller
    {
        private readonly string _baseUrl;
        // GET: ManageDemand
        private readonly string _placeDemandUriFormat = "placedemand/user/{0}/book/{1}";
        private readonly string _listDemandUriFormat = "listdemand/user/{0}";
        private readonly string _deleteDemandUriFormat = "deletedemand/user/{0}/book/{1}";
        private readonly IAuthenticationRepository _authenticationRepository;

        public ManageDemandController()
        {
            _baseUrl = WebConfigurationManager.AppSettings["ManageDemandSvcBase"];
            _authenticationRepository=new AuthenticationRepository();
        }
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var client = ClientProcessor();
            var result =
                await
                    client.GetAsync(String.Format(_listDemandUriFormat,
                        _authenticationRepository.GetUserId(User.Identity.GetUserName())));
            if (result.IsSuccessStatusCode)
            {
                var bookresponse = result.Content.ReadAsStringAsync().Result;
                var bookList = JsonConvert.DeserializeObject<List<Book>>(bookresponse);
                return View(bookList);
            }
            return View(new List<Book>());
        }

        public async System.Threading.Tasks.Task<ActionResult> PlaceDemand( string bookId)
        {
            var userId = _authenticationRepository.GetUserId(User.Identity.GetUserName());
            var client = ClientProcessor();
            var result=await client.PostAsync(String.Format(_placeDemandUriFormat, userId, bookId), null);
            
            return RedirectToAction("Index", "BookList");
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteDemand(string userId, string bookId)
        {

            var client = ClientProcessor();
            await client.DeleteAsync(String.Format(_deleteDemandUriFormat, userId, bookId));
            
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

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home");
        }
    }
}