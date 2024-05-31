using Microsoft.AspNetCore.Mvc;
using Teledoc_WebAPI.Tables;

namespace Teledoc_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FounderController : ControllerBase
    {
        IDbActions dbActions;
        public FounderController(IDbActions dbActions)
        {
            this.dbActions = dbActions;
        }

        /// <summary>
        /// Создание нового учредителя
        /// </summary>
        /// <param name="founder">Объект нового учредителя</param>
        /// <returns>Результат выполнения</returns>
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
        
        /// <summary>
        /// Обновление данных учредителя
        /// </summary>
        /// <param name="Id">id обновляемого учредителя</param>
        /// <param name="updatedFounder">Объект нового учредителя</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление учредителя
        /// </summary>
        /// <param name="Id">id удаляемого учредителя</param>
        /// <returns></returns>
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

