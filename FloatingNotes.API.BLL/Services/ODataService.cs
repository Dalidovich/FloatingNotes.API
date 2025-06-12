using FloatingNotes.API.BLL.Interfaces;
using FloatingNotes.API.DAL.Repositories.Interafaces;
using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.Enums;
using FloatingNotes.API.Domain.InnerResponse;

namespace FloatingNotes.API.BLL.Services
{
    public class ODataService : IODataService
    {
        private readonly IFloatingNoteRepositories _floatingNoteRepositories;
        private readonly IConnectionFloatingNoteRepositories _connectionFloatingNoteRepositories;

        public ODataService(IFloatingNoteRepositories floatingNoteRepositories, IConnectionFloatingNoteRepositories connectionFloatingNoteRepositories)
        {
            _floatingNoteRepositories = floatingNoteRepositories;
            _connectionFloatingNoteRepositories = connectionFloatingNoteRepositories;
        }

        public BaseResponse<IQueryable<ConnectionFloatingNote>> GetConnectionFloatingNoteOData()
        {
            var contents = _connectionFloatingNoteRepositories.GetAll();

            return new StandartResponse<IQueryable<ConnectionFloatingNote>>()
            {
                Data = contents,
                InnerStatusCode = InnerStatusCode.ConnectionFloatingNoteRead
            };
        }

        public BaseResponse<IQueryable<FloatingNote>> GetFloatingNoteOData()
        {
            var contents = _floatingNoteRepositories.GetAll();

            return new StandartResponse<IQueryable<FloatingNote>>()
            {
                Data = contents,
                InnerStatusCode = InnerStatusCode.FloatingNoteRead
            };
        }
    }
}
