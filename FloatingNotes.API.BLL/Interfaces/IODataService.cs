using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.InnerResponse;

namespace FloatingNotes.API.BLL.Interfaces
{
    public interface IODataService
    {
        public BaseResponse<IQueryable<FloatingNote>> GetFloatingNoteOData();
        public BaseResponse<IQueryable<ConnectionFloatingNote>> GetConnectionFloatingNoteOData();
    }
}
