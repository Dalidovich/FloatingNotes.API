using System.Linq.Expressions;
using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.BLL.Services.HelperService;
using FloatingNotes.API.DAL.Repositories.Interafaces;
using FloatingNotes.API.Domain.DTO;
using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.Enums;
using FloatingNotes.API.Domain.InnerResponse;
using Microsoft.EntityFrameworkCore;

namespace FloatingNotes.API.BLL.Services
{
    public class FloatingNoteService : IFloatingNoteService
    {
        private readonly IFloatingNoteRepositories _floatingNoteRepositories;

        public FloatingNoteService(IFloatingNoteRepositories floatingNoteRepositories)
        {
            _floatingNoteRepositories = floatingNoteRepositories;
        }

        public async Task<BaseResponse<FloatingNote>> CreateFloatingNote(CreateFloatingNoteDTO floatingNote)
        {
            var createdFloatingNote = await _floatingNoteRepositories.AddAsync(new FloatingNote(floatingNote));
            await _floatingNoteRepositories.SaveAsync();

            return new StandartResponse<FloatingNote>()
            {
                Data = createdFloatingNote,
                InnerStatusCode = InnerStatusCode.FloatingNoteCreate
            };
        }

        public async Task<BaseResponse<bool>> DeleteFloatingNote(Guid deleteId)
        {
            var entity = await _floatingNoteRepositories
                .GetAll()
                .Where(x => x.Id == deleteId)
                .SingleOrDefaultAsync();

            if (entity == null)
            {
                return new StandartResponse<bool>()
                {
                    Data = false,
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            var response = await _floatingNoteRepositories.Delete(deleteId);

            return new StandartResponse<bool>()
            {
                Data = response,
                InnerStatusCode = InnerStatusCode.FloatingNoteDelete
            };
        }

        public async Task<BaseResponse<FloatingNote>> GetFloatingNote(Expression<Func<FloatingNote, bool>> expression)
        {
            var entity = await _floatingNoteRepositories.GetAll().SingleOrDefaultAsync(expression);
            if (entity == null)
            {
                return new StandartResponse<FloatingNote>()
                {
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            return new StandartResponse<FloatingNote>()
            {
                Data = entity,
                InnerStatusCode = InnerStatusCode.FloatingNoteRead
            };
        }

        public async Task<BaseResponse<IEnumerable<FloatingNote>>> GetFloatingNotes(Expression<Func<FloatingNote, bool>> expression)
        {
            var entities = await _floatingNoteRepositories.GetAll().Where(expression).ToListAsync();

            return new StandartResponse<IEnumerable<FloatingNote>>()
            {
                Data = entities,
                InnerStatusCode = InnerStatusCode.FloatingNoteRead
            };
        }

        public async Task<BaseResponse<FloatingNote>> UpdateFloatingNote(UserUpdateFloatingNoteDTO updateFloatingNoteDTO)
        {
            var updateEntity = await _floatingNoteRepositories.GetAll().Where(x => x.Id == updateFloatingNoteDTO.Id).SingleOrDefaultAsync();

            if (updateEntity == null)
            {
                return new StandartResponse<FloatingNote>()
                {
                    Data = updateEntity,
                    InnerStatusCode = InnerStatusCode.EntityNotFound
                };
            }

            updateEntity.PutUpdateData(updateFloatingNoteDTO);
            _floatingNoteRepositories.Update(updateEntity);
            await _floatingNoteRepositories.SaveAsync();

            return new StandartResponse<FloatingNote>()
            {
                Data = updateEntity,
                InnerStatusCode = InnerStatusCode.FloatingNoteUpdate
            };
        }
    }
}
