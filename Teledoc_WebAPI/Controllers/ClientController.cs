using Microsoft.AspNetCore.Mvc;
using Teledoc_WebAPI.Tables;

namespace Teledoc_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IDbActions dbActions;
        public ClientController(IDbActions dbActions)
        {
            this.dbActions = dbActions;
        }

        /// <summary>
        /// Просмотр всех клиентов
        /// </summary>
        /// <returns>Перечисление клиентов</returns>
        [HttpGet(Name = "GetAllClients")]
        public IEnumerable<Client> GetClients()
        {
            return dbActions.GetClients();
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="client">Объект нового клиента</param>
        /// <returns>Результат выполнения</returns>
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

        /// <summary>
        /// Обновить данные клиента
        /// </summary>
        /// <param name="Id">id обновляемого клиента</param>
        /// <param name="updatedClient">объект нового клиента</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="Id">id удаляемого клиента</param>
        /// <returns>Результат выполнения</returns>
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
    }
}

