using System.Linq.Expressions;
using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.DAL.Repositories.Interafaces;
using FloatingNotes.API.Domain.DTO;
using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.Enums;
using FloatingNotes.API.Domain.InnerResponse;
using Microsoft.EntityFrameworkCore;

namespace FloatingNotes.API.BLL.Services
{
    public class ConnectionFloatingNoteService : IConnectionFloatingNoteService
    {
        private readonly IConnectionFloatingNoteRepositories _connectionFloatingNoteRepositories;
        private readonly IFloatingNoteRepositories _floatingNoteRepositories;

        public ConnectionFloatingNoteService(IConnectionFloatingNoteRepositories connectionFloatingNoteRepositories, IFloatingNoteRepositories floatingNoteRepositories)
        {
            _connectionFloatingNoteRepositories = connectionFloatingNoteRepositories;
            _floatingNoteRepositories = floatingNoteRepositories;
        }

        public async Task<BaseResponse<ConnectionFloatingNote>> CreateConnectionFloatingNote(ConnectionFloatingNoteDTO connectionFloatingNoteDTO)
        {
            var noteEntity = await _floatingNoteRepositories
                .GetAll()
                .Where(x => x.Id == connectionFloatingNoteDTO.MasterFloatingNoteId)
                .SingleOrDefaultAsync();

            var connectionEntity = await _floatingNoteRepositories
                .GetAll()
                .Where(x => x.Id == connectionFloatingNoteDTO.ConnectedFloatingNoteId)
                .SingleOrDefaultAsync();

            if (noteEntity == null || connectionEntity == null)
            {
                return new StandartResponse<ConnectionFloatingNote>()
                {
                    Data = null,
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            var existConnectionEntity = await _connectionFloatingNoteRepositories
                .GetAll()
                .Where(x => x.MasterFloatingNoteId == connectionFloatingNoteDTO.MasterFloatingNoteId)
                .Where(x => x.ConnectedFloatingNoteId == connectionFloatingNoteDTO.ConnectedFloatingNoteId)
                .SingleOrDefaultAsync();

            if (existConnectionEntity != null)
            {
                existConnectionEntity.MasterFloatingNote.ConnectedFloatingNotes.Clear();
                existConnectionEntity.ConnectedFloatingNote.ConnectedFloatingNotes.Clear();

                return new StandartResponse<ConnectionFloatingNote>()
                {
                    Data = existConnectionEntity,
                    InnerStatusCode = InnerStatusCode.ConnectionFloatingNoteExist
                };
            }

            var entity = await _connectionFloatingNoteRepositories.AddAsync(new(connectionFloatingNoteDTO));
            await _connectionFloatingNoteRepositories.SaveAsync();

            entity.MasterFloatingNote.ConnectedFloatingNotes.Clear();
            entity.ConnectedFloatingNote.ConnectedFloatingNotes.Clear();

            return new StandartResponse<ConnectionFloatingNote>()
            {
                Data = entity,
                InnerStatusCode = InnerStatusCode.ConnectionFloatingNoteCreate
            };
        }

        public async Task<BaseResponse<bool>> DeleteConnectionFloatingNote(ConnectionFloatingNoteDTO connectionFloatingNoteDTO)
        {
            var noteEntity = await _floatingNoteRepositories
                .GetAll()
                .Where(x => x.Id == connectionFloatingNoteDTO.MasterFloatingNoteId)
                .SingleOrDefaultAsync();

            var connectionEntity = await _floatingNoteRepositories
                .GetAll()
                .Where(x => x.Id == connectionFloatingNoteDTO.ConnectedFloatingNoteId)
                .SingleOrDefaultAsync();

            if (noteEntity == null || connectionEntity == null)
            {
                return new StandartResponse<bool>()
                {
                    Data = false,
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            var entity = await _connectionFloatingNoteRepositories.Delete(connectionFloatingNoteDTO.MasterFloatingNoteId, connectionFloatingNoteDTO.ConnectedFloatingNoteId);

            return new StandartResponse<bool>()
            {
                Data = true,
                InnerStatusCode = InnerStatusCode.ConnectionFloatingNoteDelete
            };
        }

        public async Task<BaseResponse<IEnumerable<ConnectionFloatingNote>>> GetFloatingNotes(Expression<Func<ConnectionFloatingNote, bool>> expression)
        {
            var entities = await _connectionFloatingNoteRepositories.GetAll().Where(expression).ToListAsync();

            return new StandartResponse<IEnumerable<ConnectionFloatingNote>>()
            {
                Data = entities,
                InnerStatusCode = InnerStatusCode.ConnectionFloatingNoteRead
            };
        }
    }
}
