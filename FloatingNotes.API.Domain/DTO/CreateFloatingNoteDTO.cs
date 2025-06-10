using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.DTO
{
    public class CreateFloatingNoteDTO
    {
        public string Content { get; set; }
        public string? Title { get; set; }
        public FloatingNoteType Type { get; set; }
    }
}
