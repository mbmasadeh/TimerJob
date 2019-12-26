using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimerJob.Data;
using TimerJob.Services;
using TimerJob.ViewModel;

namespace TimerJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TimerContext _Context;
        private readonly ServiceManager _service;
        public ValuesController(TimerContext Context, ServiceManager Service)
        {
            _Context = Context;
            _service = Service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<InfoTableViewModel> Get()
        {
            var service = _service.NewService<InfoService>(_Context);
            var setRead = service.MoveData();
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
