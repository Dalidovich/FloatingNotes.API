using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.InnerResponse
{
    public class StandartResponse<T> : BaseResponse<T>
    {
        public override string Message { get; set; } = null!;
        public override InnerStatusCode InnerStatusCode { get; set; }
        public override T Data { get; set; }
    }
}
