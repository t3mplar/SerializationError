using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SerializationError.Controllers
{
    public class Foo
    {
        [JsonProperty(Required = Required.Always)]
        public string Bar { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Throws serialization exception. Never caught.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get1")]
        public ActionResult<Foo> Get1()
        {
            return new Foo();
        }

        /// <summary>
        /// Throws serialization exception. Never caught.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get2")]
        public Foo Get(int id)
        {
            return new Foo();
        }

        /// <summary>
        /// Throws serialization exception. Never caught.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get3")]
        public ActionResult<Foo> Get3()
        {
            return Ok(new Foo());
        }

        /// <summary>
        /// Throws serialization exception. Never caught.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get4")]
        public ActionResult Get4()
        {
            return Ok(new Foo());
        }

        /// <summary>
        /// Throws argument exception. Caught and hanled properly.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get5")]
        public ActionResult Get5()
        {
            throw new ArgumentException();
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <returns></returns>
        [HttpGet("get6")]
        public ActionResult Get6()
        {
            return Ok(new Foo() { Bar = "test" });
        }
    }
}
