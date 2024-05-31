using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teledoc_WebAPI.Tables;

namespace Teledoc_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeledocDbController : ControllerBase
    {
        IDbActions dbActions;
        public TeledocDbController(IDbActions dbActions)
        {
            this.dbActions = dbActions;
        }

        [HttpGet(Name = "GetAllClients")]
        public IEnumerable<Client> GetClients()
        {
            return dbActions.GetClients();
        }

        [HttpPost]
        [Route("CreateClient")]
        public IActionResult CreateClient([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            dbActions.CreateClient(client);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateClient")]
        public IActionResult UpdateClient(int Id, [FromBody] Client updatedClient)
        {
            if (updatedClient == null || updatedClient.Id != Id)
            {
                return BadRequest();
            }

            var client = dbActions.GetClient(Id);
            if (client == null)
            {
                return NotFound();
            }

            dbActions.UpdateClient(updatedClient);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteClient")]
        public IActionResult DeleteClient(int Id)
        {
            var deletedClient = dbActions.DeleteClient(Id);

            if (deletedClient == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedClient);
        }

        [HttpPost]
        [Route("CreateFounder")]
        public IActionResult CreateFounder([FromBody] Founder founder)
        {
            if (founder == null)
            {
                return BadRequest();
            }
            dbActions.CreateFounder(founder);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateFounder")]
        public IActionResult UpdateFounder(int Id, [FromBody] Founder updatedFounder)
        {
            if (updatedFounder == null || updatedFounder.Id != Id)
            {
                return BadRequest();
            }

            var client = dbActions.GetFounder(Id);
            if (client == null)
            {
                return NotFound();
            }

            dbActions.UpdateFounder(updatedFounder);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteFounder")]
        public IActionResult DeleteFounder(int Id)
        {
            var deletedFounder = dbActions.DeleteFounder(Id);

            if (deletedFounder == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedFounder);
        }
    }
}

