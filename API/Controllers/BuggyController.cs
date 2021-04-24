using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _Context;
        public BuggyController(StoreContext storeContext)
        {
            _Context = storeContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest(){
             var thing = _Context.Products.Find(24);
             if( thing == null){
                 return NotFound(new ApiResponse(404));
             }
             return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError(){
          var thing = _Context.Products.Find(24);
            var things = thing.ToString();
             return Ok();
        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest(){
          var thing = _Context.Products.Find(24);
             if( thing == null){
                 return NotFound(new ApiResponse(400));
             }
             return Ok();
        }


        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequesr(int id){
          var thing = _Context.Products.Find(24);
             if( thing == null){
                 return NotFound(new ApiResponse(404));
             }
             return Ok();
        }

    }
}