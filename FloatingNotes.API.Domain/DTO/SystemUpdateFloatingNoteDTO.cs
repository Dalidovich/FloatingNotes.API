using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.DTO
{
    public class SystemUpdateFloatingNoteDTO
    {
        public Guid? Id { get; set; }
        public new int? Number { get; set; }
        public new FloatingNoteStatus? Status { get; set; }
        public new bool? IsIncludedInResponseProcessing { get; set; }
    }
}
