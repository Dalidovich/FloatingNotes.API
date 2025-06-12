using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace FloatingNotes.API.Controllers
{
    public class BaseODataController : ODataController
    {
        private readonly IODataService _ODataService;

        public BaseODataController(IODataService ODataService)
        {
            _ODataService = ODataService;
        }

        [HttpGet("odata/FloatingNote")]
        [EnableQuery]
        public IQueryable<FloatingNote> GetFloatingNote()
        {
            return _ODataService.GetFloatingNoteOData().Data;
        }

        [HttpGet("odata/ConnectionFloatingNote")]
        [EnableQuery]
        public IQueryable<ConnectionFloatingNote> GetConnectionFloatingNote()
        {
            return _ODataService.GetConnectionFloatingNoteOData().Data;
        }
    }
}
