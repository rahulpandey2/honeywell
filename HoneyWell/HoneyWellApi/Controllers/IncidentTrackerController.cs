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
            try
            {
                return new JsonResult(_service.GetIncidentTrackers(), new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception e)
            {
                return new JsonResult(e.InnerException, new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }


        [HttpGet("{incidentTrackerId}")]
        public IActionResult Get(int incidentTrackerId)
        {
            try
            {
                return new JsonResult(_service.GetIncident(incidentTrackerId),
                new JsonSerializerSettings { Formatting = Formatting.Indented })
                { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception e)
            {
                return new JsonResult(e.InnerException, new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncidentTracker incidentTracker)
        {
            try
            {
                if (incidentTracker != null && !string.IsNullOrEmpty(incidentTracker.IncidentId))
                {
                    return new JsonResult(_service.Create(incidentTracker),
                    new JsonSerializerSettings { Formatting = Formatting.Indented })
                    { StatusCode = StatusCodes.Status200OK };
                }
                return new JsonResult("incidentId is required", new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status400BadRequest };
            }
            catch (Exception e)
            {
                return new JsonResult(e.InnerException, new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status500InternalServerError };
            }

        }
        [HttpPut("{incidentTrackerId}")]
        public IActionResult Put(int incidentTrackerId, [FromBody] IncidentTracker incidentTracker)
        {
            try
            {
                if (incidentTracker != null && incidentTrackerId > 0)
                    incidentTracker.IncidentTrackerId = incidentTrackerId;

                return new JsonResult(_service.Update(incidentTracker),
                      new JsonSerializerSettings { Formatting = Formatting.Indented })
                { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception e)
            {
                return new JsonResult(e.InnerException, new JsonSerializerSettings { Formatting = Formatting.Indented }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
        [HttpDelete("{incidentTrackerId}")]
        public void Delete(int incidentTrackerId)
        {
            try
            {
                _service.Delete(incidentTrackerId);
            }

            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
