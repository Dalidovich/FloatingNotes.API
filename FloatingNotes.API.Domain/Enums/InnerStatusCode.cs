namespace FloatingNotes.API.Domain.Enums
{
    public enum InnerStatusCode
    {
        EntityNotFound = 0,

        FloatingNoteCreate = 1,
        FloatingNoteUpdate = 2,
        FloatingNoteDelete = 3,
        FloatingNoteRead = 4,
        FloatingNoteExist = 5,

        InitAvailableNumber = 6,
        GetAvailableNumber = 7,
        SetAvailableNumber = 8,

        OK = 200,
        OKNoContent = 204,
        InternalServerError = 500,
    }
}
