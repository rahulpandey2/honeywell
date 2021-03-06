using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentTrackerService;
using Newtonsoft.Json;
using IncidentTrackerModal;

namespace HoneyWell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentTrackerController : ControllerBase
    {
        private IService _service;
        public IncidentTrackerController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_service.GetIncidentTrackers(), new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status200OK };
        }

       
        [HttpGet("{incidentTrackerId}")]
        public IActionResult Get(int incidentTrackerId)
        {
            return new JsonResult(_service.GetIncident(incidentTrackerId),
                new JsonSerializerSettings { Formatting = Formatting.Indented })
            { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncidentTracker incidentTracker)
        {
            if (incidentTracker != null && !string.IsNullOrEmpty(incidentTracker.IncidentId))
            {
                return new JsonResult(_service.Create(incidentTracker),
                new JsonSerializerSettings { Formatting = Formatting.Indented })
                { StatusCode = StatusCodes.Status200OK };
            }
            return new JsonResult("Product Name is required", new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status400BadRequest };
        }
        [HttpPut("{incidentTrackerId}")]
        public IActionResult Put(int incidentTrackerId, [FromBody] IncidentTracker incidentTracker)
        {
            if (incidentTracker != null && incidentTrackerId > 0)
                incidentTracker.IncidentTrackerId = incidentTrackerId;

            return new JsonResult(_service.Update(incidentTracker),
                  new JsonSerializerSettings { Formatting = Formatting.Indented })
            { StatusCode = StatusCodes.Status200OK };
        }
        [HttpDelete("{incidentTrackerId}")]
        public void Delete(int incidentTrackerId)
        {
            _service.Delete(incidentTrackerId);
        }
    }
}
