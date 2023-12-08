using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Myta.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myta.Api.Controllers
{
    [Route("api/error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("error_500")]
        public IActionResult Error500(string exMessage)
        {
            return new ErrorResult(ApiCodes.E500, exMessage).Result;
        }
    }
}
