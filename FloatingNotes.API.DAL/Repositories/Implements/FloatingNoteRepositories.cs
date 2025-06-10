using FloatingNotes.API.DAL.Repositories.Interafaces;
using FloatingNotes.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloatingNotes.API.DAL.Repositories.Implements
{
    public class FloatingNoteRepositories : IFloatingNoteRepositories
    {
        private readonly AppDBContext _db;

        public FloatingNoteRepositories(AppDBContext db)
        {
            _db = db;
        }

        public async Task<FloatingNote> AddAsync(FloatingNote entity)
        {
            var createdEntity = await _db.FloatingNotes.AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task<bool> Delete(Guid deleteId)
        {
            await _db.FloatingNotes.Where(x => x.Id == deleteId).ExecuteDeleteAsync();

            return true;
        }

        public IQueryable<FloatingNote> GetAll()
        {
            return _db.FloatingNotes;
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }

        public FloatingNote Update(FloatingNote entity)
        {
            var updatedEntity = _db.FloatingNotes.Update(entity);

            return updatedEntity.Entity;
        }
    }
}
