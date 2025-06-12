using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FloatingNotes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionFloatingNoteController : ControllerBase
    {
        private readonly IConnectionFloatingNoteService _connectionfloatingNoteService;

        public ConnectionFloatingNoteController(IConnectionFloatingNoteService connectionfloatingNoteService)
        {
            _connectionfloatingNoteService = connectionfloatingNoteService;
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateConnectionFloatingNote([FromQuery] ConnectionFloatingNoteDTO connectionFloatingNote)
        {
            if (connectionFloatingNote == null)
            {
                return BadRequest();
            }
            var resourse = await _connectionfloatingNoteService.CreateConnectionFloatingNote(connectionFloatingNote);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.ConnectionFloatingNoteCreate)
            {
                return Ok(resourse.Data);
            }
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.EntityNotFound)
            {
                return NoContent();
            }
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.ConnectionFloatingNoteExist)
            {
                return Conflict(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpGet("read/")]
        public async Task<IActionResult> ReadConnectionFloatingNotes()
        {
            var resourse = await _connectionfloatingNoteService.GetFloatingNotes(x => x.MasterFloatingNoteId != null);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.ConnectionFloatingNoteRead)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpDelete("delete/")]
        public async Task<IActionResult> DeleteConnectionFloatingNotes([FromQuery] ConnectionFloatingNoteDTO connectionFloatingNoteDTO)
        {
            var resourse = await _connectionfloatingNoteService.DeleteConnectionFloatingNote(connectionFloatingNoteDTO);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.ConnectionFloatingNoteDelete)
            {
                return Ok(resourse.Data);
            }
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.EntityNotFound)
            {
                return NoContent();
            }

            return StatusCode(500);
        }
    }
}
