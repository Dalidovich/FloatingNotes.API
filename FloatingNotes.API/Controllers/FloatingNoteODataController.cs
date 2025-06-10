using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace FloatingNotes.API.Controllers
{
    public class FloatingNoteODataController : ODataController
    {
        private readonly IFloatingNoteService _floatingNoteService;

        public FloatingNoteODataController(IFloatingNoteService floatingNoteService)
        {
            _floatingNoteService = floatingNoteService;
        }

        [HttpGet("odata/FloatingNote")]
        [EnableQuery]
        public IQueryable<FloatingNote> GetComment()
        {
            return _floatingNoteService.GetFloatingNoteOData().Data;
        }
    }
}
