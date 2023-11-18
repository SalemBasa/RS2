namespace TrashTrack.Core
{
    public class QuizUpsertDto : BaseUpsertDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<QuestionUpsertDto> Questions { get; set; } = null!;
    }
}
