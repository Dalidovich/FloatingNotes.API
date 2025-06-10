using FloatingNotes.API.Domain.DTO;
using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.Entities
{
    public class FloatingNote
    {
        public Guid? Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public string AITitle { get; set; }
        public string AIContent { get; set; }

        public int Number { get; set; }
        public FloatingNoteType Type { get; set; }
        public DateTime CreateDate { get; set; }
        public FloatingNoteStatus Status { get; set; }
        public bool IsIncludedInResponseProcessing { get; set; }

        public FloatingNote()
        {
        }

        public FloatingNote(CreateFloatingNoteDTO createFloatingNoteDTO)
        {
            Content = createFloatingNoteDTO.Content;
            Title = createFloatingNoteDTO.Title ?? "";

            AITitle = "";
            AIContent = "";

            Number = 0;
            Type = createFloatingNoteDTO.Type;
            CreateDate = DateTime.Now;
            Status = FloatingNoteStatus.created;

            IsIncludedInResponseProcessing = true;
        }
    }
}
