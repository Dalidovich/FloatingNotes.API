using FloatingNotes.API.Domain.Entities;
using FloatingNotes.API.Domain.Enums;

namespace FloatingNotes.API.BLL.Services.HelperService
{
    public class UpdateFloatingNoteBuilder
    {
        private FloatingNote _Instance;
        private UpdateFloatingNoteBuilder _InstanceBuilder;

        public UpdateFloatingNoteBuilder(FloatingNote note)
        {
            _Instance = note;
            _InstanceBuilder = this;
        }

        public UpdateFloatingNoteBuilder BuildContent(string? content)
        {
            _Instance.Content = content ?? _Instance.Content;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildTitle(string? title)
        {
            _Instance.Title = title ?? _Instance.Title;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildAITitle(string? aiTitle)
        {
            _Instance.AITitle = aiTitle ?? _Instance.AITitle;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildAIContent(string? aiContent)
        {
            _Instance.AIContent = aiContent ?? _Instance.AIContent;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildNumber(int? number)
        {
            _Instance.Number = number ?? _Instance.Number;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildType(FloatingNoteType? type)
        {
            _Instance.Type = type ?? _Instance.Type;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildStatus(FloatingNoteStatus? status)
        {
            _Instance.Status = status ?? _Instance.Status;

            return _InstanceBuilder;
        }

        public UpdateFloatingNoteBuilder BuildIsIncludedInResponseProcessing(bool? isIncludedInResponseProcessing)
        {
            _Instance.IsIncludedInResponseProcessing = isIncludedInResponseProcessing ?? _Instance.IsIncludedInResponseProcessing;

            return _InstanceBuilder;
        }

        public FloatingNote Build() => _Instance;
    }
}
