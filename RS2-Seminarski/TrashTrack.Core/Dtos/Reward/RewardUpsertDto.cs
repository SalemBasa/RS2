namespace TrashTrack.Core
{
    public class RewardUpsertDto : BaseUpsertDto
    {
        public int UserId { get; set; }

        public int QuizId { get; set; }

        public int Score { get; set; }
        public decimal MoneyEarned { get; set; }
    }
}
