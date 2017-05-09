using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CompanyName.BusinessLayer.Repositories.Interfaces;

namespace CompanyName.Services.ManageDemand.Controllers
{
    public class ManageDemandController : ApiController
    {
        private readonly IBookDatarepository _bookDatarepository;
        private readonly IManageOrderRepository _manageOrderRepository;

        public ManageDemandController(IBookDatarepository bookDatarepository, IManageOrderRepository manageOrderRepository)
        {
            _bookDatarepository = bookDatarepository;
            _manageOrderRepository = manageOrderRepository;
        }

       // [HttpGet]
        [Route("listdemand/user/{userId}")]
        public HttpResponseMessage Get(string userId)
        {
            try
            {
                var bookList = _manageOrderRepository.ListOrders(userId);

                return Request.CreateResponse(HttpStatusCode.OK, bookList);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("placedemand/user/{userId}/book/{bookId}")]
        public async Task<HttpResponseMessage> Post(string userId, string bookId)
        {
            try
            {
                var result = await _manageOrderRepository.PlaceOrder(userId, bookId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("deletedemand/user/{userId}/book/{bookId}")]
        public async Task<HttpResponseMessage> Delete(string userId, string bookId)
        {
            try
            {
                var result = await _manageOrderRepository.DeleteOrder(userId, bookId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
