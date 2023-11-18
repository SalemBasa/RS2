namespace TrashTrack.Core
{
    public class QuestionUpsertDto : BaseUpsertDto
    {
        public string Content { get; set; } = null!;
        public int Points { get; set; }

        public ICollection<AnswerUpsertDto> Answers { get; set; } = null!;
    }
}
