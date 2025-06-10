using System.Linq.Expressions;
using FloatingNotes.API.Domain.DTO;
using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.InnerResponse;

namespace FloatingNotes.API.BLL.Interfaces
{
    public interface IFloatingNoteService
    {
        public Task<BaseResponse<FloatingNote>> GetFloatingNote(Expression<Func<FloatingNote, bool>> expression);
        public Task<BaseResponse<IEnumerable<FloatingNote>>> GetFloatingNotes(Expression<Func<FloatingNote, bool>> expression);
        public Task<BaseResponse<FloatingNote>> CreateFloatingNote(CreateFloatingNoteDTO floatingNote);
        public Task<BaseResponse<FloatingNote>> UpdateFloatingNote(UserUpdateFloatingNoteDTO updateFloatingNoteDTO);
        public Task<BaseResponse<bool>> DeleteFloatingNote(Guid deleteId);
        public BaseResponse<IQueryable<FloatingNote>> GetFloatingNoteOData();
    }
}
