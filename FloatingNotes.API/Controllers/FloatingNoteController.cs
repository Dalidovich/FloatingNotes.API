using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FloatingNotes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloatingNoteController : ControllerBase
    {
        private readonly IFloatingNoteService _floatingNoteService;

        public FloatingNoteController(IFloatingNoteService floatingNoteService)
        {
            _floatingNoteService = floatingNoteService;
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateFloatingNote([FromQuery] CreateFloatingNoteDTO floatingNoteDTO)
        {
            if (floatingNoteDTO == null)
            {
                return BadRequest();
            }
            var resourse = await _floatingNoteService.CreateFloatingNote(floatingNoteDTO);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.FloatingNoteCreate)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpGet("read/")]
        public async Task<IActionResult> ReadFloatingNotes()
        {
            var resourse = await _floatingNoteService.GetFloatingNotes(x => x.Id != null);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.FloatingNoteRead)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpDelete("delete/")]
        public async Task<IActionResult> DeleteFloatingNotes([FromQuery] Guid deleteId)
        {
            var resourse = await _floatingNoteService.DeleteFloatingNote(deleteId);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.FloatingNoteDelete)
            {
                return Ok(resourse.Data);
            }
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.EntityNotFound)
            {
                return NoContent();
            }

            return StatusCode(500);
        }

        [HttpPut("update/")]
        public async Task<IActionResult> UpdateFloatingNotes([FromQuery] UserUpdateFloatingNoteDTO userUpdateFloatingNoteDTO)
        {
            var resourse = await _floatingNoteService.UpdateFloatingNote(userUpdateFloatingNoteDTO);
            if (resourse.InnerStatusCode == Domain.Enums.InnerStatusCode.FloatingNoteUpdate)
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
