using FloatingNotes.API.Domain.Entities;

namespace FloatingNotes.API.DAL.Repositories.Interafaces
{
    public interface IConnectionFloatingNoteRepositories
    {
        public Task<ConnectionFloatingNote> AddAsync(ConnectionFloatingNote entity);
        public ConnectionFloatingNote Update(ConnectionFloatingNote entity);
        public Task<bool> Delete(Guid deleteMasterId, Guid deleteConnectedId);
        public IQueryable<ConnectionFloatingNote> GetAll();
        public Task<bool> SaveAsync();
    }
}
