using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.DTO
{
    public class AIUpdateFloatingNoteDTO
    {
        public Guid? Id { get; set; }
        public new string? Title { get; set; }
        public new string? AITitle { get; set; }
        public new string? AIContent { get; set; }
        public new FloatingNoteType Type { get; set; }
    }
}
