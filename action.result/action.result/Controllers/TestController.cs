using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace action.result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Testing(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if(id == 1)
            {
                return BadRequest();
            }

            return Ok(id);
        }
    }
}
