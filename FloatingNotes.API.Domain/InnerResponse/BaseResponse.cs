using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.Domain.InnerResponse
{
    public abstract class BaseResponse<T>
    {
        public virtual T Data { get; set; }
        public virtual InnerStatusCode InnerStatusCode { get; set; }
        public virtual string Message { get; set; }
    }
}
