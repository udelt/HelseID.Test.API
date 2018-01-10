using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;

namespace HelseID.Test.API.FullFramework.Controllers
{
    [Authorize]
    public class ReturnTokenContentController : ApiController
    {
        // GET: api/ReturnTokenContent
        public IHttpActionResult Get()
        {
            if (!(User is ClaimsPrincipal user)) return StatusCode(HttpStatusCode.Unauthorized);

            if (user.Claims == null) return Ok("No claims");
             
            var claims = from c in user.Claims
                select new
                {
                    type = c.Type,
                    value = c.Value
                };

            var result = claims.ToList();

            if (result.Count > 0)
                return Json(result);

            return Json("No available claims");
        }

        // POST: api/ReturnTokenContent
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ReturnTokenContent/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
