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
    [RoutePrefix("SubCategory")]
    public class SubCategoryController : ApiController
    {
        [Route("addSubCategory")]
        [HttpPost]
        public IHttpActionResult AddSubCategory([FromBody]Sub_categoryDTO subCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(SubCategoryLogic.AddSubCategory(subCategory));
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
        [Route("getSubCategoriesForCategory")]
        [HttpGet]
        public IHttpActionResult getSubCategoriesForCategory(int categoryId)
        {
            try
            {
                return Ok(SubCategoryLogic.GetSubCategoriesForCategory(categoryId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}