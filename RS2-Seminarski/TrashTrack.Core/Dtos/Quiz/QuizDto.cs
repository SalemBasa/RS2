namespace TrashTrack.Core
{
    public class QuizDto : BaseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<QuestionDto> Questions { get; set; } = null!;
    }
}
