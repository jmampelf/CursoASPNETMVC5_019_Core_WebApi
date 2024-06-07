using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoASPNETMVC5_019_Core_WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController: ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Running...";
        }



    }
}
