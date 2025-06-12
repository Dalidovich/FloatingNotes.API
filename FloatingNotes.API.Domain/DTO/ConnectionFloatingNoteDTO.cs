namespace FloatingNotes.API.Domain.DTO
{
    public class ConnectionFloatingNoteDTO
    {
        public Guid MasterFloatingNoteId { get; set; }
        public Guid ConnectedFloatingNoteId { get; set; }
    }
}
