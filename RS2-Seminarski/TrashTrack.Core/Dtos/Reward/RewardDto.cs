namespace TrashTrack.Core
{
    public class RewardDto : BaseDto
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;

        public int Score { get; set; }
        public decimal MoneyEarned { get; set; }
    }
}
