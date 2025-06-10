using FloatingNotes.API.Domain.Entities;

namespace FloatingNotes.API.DAL.Repositories.Interafaces
{
    public interface IFloatingNoteRepositories
    {
        public Task<FloatingNote> AddAsync(FloatingNote entity);
        public FloatingNote Update(FloatingNote entity);
        public Task<bool> Delete(Guid deleteId);
        public IQueryable<FloatingNote> GetAll();
        public Task<bool> SaveAsync();
    }
}
