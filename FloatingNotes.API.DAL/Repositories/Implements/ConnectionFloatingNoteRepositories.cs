using FloatingNotes.API.DAL.Repositories.Interafaces;
using FloatingNotes.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloatingNotes.API.DAL.Repositories.Implements
{
    public class ConnectionFloatingNoteRepositories : IConnectionFloatingNoteRepositories
    {
        private readonly AppDBContext _db;

        public ConnectionFloatingNoteRepositories(AppDBContext db)
        {
            _db = db;
        }

        public async Task<ConnectionFloatingNote> AddAsync(ConnectionFloatingNote entity)
        {
            var createdEntity = await _db.ConnectionFloatingNotes.AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task<bool> Delete(Guid deleteMasterId, Guid deleteConnectedId)
        {
            await _db.ConnectionFloatingNotes
                     .Where(x => x.MasterFloatingNote.Id == deleteMasterId)
                     .Where(x => x.ConnectedFloatingNoteId == deleteConnectedId)
                     .ExecuteDeleteAsync();

            return true;
        }

        public IQueryable<ConnectionFloatingNote> GetAll()
        {
            return _db.ConnectionFloatingNotes;
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }

        public ConnectionFloatingNote Update(ConnectionFloatingNote entity)
        {
            var updatedEntity = _db.ConnectionFloatingNotes.Update(entity);

            return updatedEntity.Entity;
        }
    }
}
