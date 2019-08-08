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
    [RoutePrefix("Question")]
    public class QuestionController : ApiController
    {
        [Route("addQuestion")]
        [HttpPost]
        public IHttpActionResult AddQuestion([FromBody]QuestionDTO question)
        {
            try
            {
                return Ok(QuestionLogic.AddQuestion(question));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
