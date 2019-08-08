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
    [RoutePrefix("Category")]
    public class CategoryController : ApiController
    {
        [Route("addCategory")]
        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]CategoryDTO category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(CategoryLogic.AddCategory(category));
                }
                var errors = ModelState.Select(x => x.Value.Errors)
                   .Where(y => y.Count > 0)
                   .ToList();
                return BadRequest(errors.ToString());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getCategoriesForTeacher")]
        [HttpGet]
        public IHttpActionResult GetCategoriesForTeacher(int teacherId)
        {
            try
            {
                return Ok(CategoryLogic.GetCategoriesForTeacher(teacherId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}