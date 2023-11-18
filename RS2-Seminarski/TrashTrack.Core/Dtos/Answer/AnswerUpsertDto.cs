namespace TrashTrack.Core
{
    public class AnswerUpsertDto : BaseUpsertDto
    {
        public string Content { get; set; } = null!;
        public bool IsTrue { get; set; }
    }
}
