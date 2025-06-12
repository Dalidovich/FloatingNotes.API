using System.Linq.Expressions;
using FloatingNotes.API.Domain.DTO;
using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.InnerResponse;

namespace FloatingNotes.API.BLL.Interfaces
{
    public interface IConnectionFloatingNoteService
    {
        public Task<BaseResponse<ConnectionFloatingNote>> CreateConnectionFloatingNote(ConnectionFloatingNoteDTO connectionFloatingNoteDTO);
        public Task<BaseResponse<bool>> DeleteConnectionFloatingNote(ConnectionFloatingNoteDTO connectionFloatingNoteDTO);
        public Task<BaseResponse<IEnumerable<ConnectionFloatingNote>>> GetFloatingNotes(Expression<Func<ConnectionFloatingNote, bool>> expression);
    }
}
