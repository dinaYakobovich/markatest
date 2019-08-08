using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Test")]
    public class TestController : ApiController
    {
        [Route("addTest")]
        [HttpPost]
        public IHttpActionResult AddTest([FromBody]TestDTO test)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(TestLogic.AddTest(test));
                }
                var errors = ModelState.Select(x => x.Value.Errors)
                   .Where(y => y.Count > 0)
                   .ToList();
                return BadRequest(errors.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
