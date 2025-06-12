using FloatingNotes.API.Domain.DTO;

namespace FloatingNotes.API.Domain.Entities
{
    public class ConnectionFloatingNote
    {
        public Guid? MasterFloatingNoteId { get; set; }
        public FloatingNote MasterFloatingNote { get; set; }

        public Guid? ConnectedFloatingNoteId { get; set; }
        public FloatingNote ConnectedFloatingNote { get; set; }

        public ConnectionFloatingNote(ConnectionFloatingNoteDTO connectionFloatingNoteDTO)
        {
            MasterFloatingNoteId = connectionFloatingNoteDTO.MasterFloatingNoteId;
            ConnectedFloatingNoteId = connectionFloatingNoteDTO.ConnectedFloatingNoteId;
        }

        public ConnectionFloatingNote()
        {
        }
    }
}
