using FloatingNotes.API.Domain.DTO;
using FloatingNotes.API.Domain.Entities;

namespace FloatingNotes.API.BLL.Services.HelperService
{
    public static class UpdateFloatingNoteHelperService
    {
        public static FloatingNote PutUpdateData(this FloatingNote floatingNote, UserUpdateFloatingNoteDTO updateData)
        {
            return new UpdateFloatingNoteBuilder(floatingNote)
                .BuildContent(updateData.Content)
                .BuildTitle(updateData.Title)
                .BuildType(updateData.Type)
                .BuildIsIncludedInResponseProcessing(updateData.IsIncludedInResponseProcessing)
                .Build();
        }
    }
}
