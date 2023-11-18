namespace TrashTrack.Core
{
    public class FeedbackUpsertDto : BaseUpsertDto
    {
        public string? Comment { get; set; }
        public int Rating { get; set; }

        public int UserId { get; set; }
    }
}
