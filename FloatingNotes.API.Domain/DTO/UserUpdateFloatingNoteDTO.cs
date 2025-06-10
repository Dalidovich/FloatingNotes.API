using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.DTO
{
    public class UserUpdateFloatingNoteDTO
    {
        public Guid? Id { get; set; }
        public string? Content { get; set; }
        public string? Title { get; set; }

        public FloatingNoteType? Type { get; set; }
        public bool? IsIncludedInResponseProcessing { get; set; }

    }
}
