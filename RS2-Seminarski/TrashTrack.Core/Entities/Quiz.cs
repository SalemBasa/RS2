namespace TrashTrack.Core
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Reward> Rewards { get; set; } = null!;
        public ICollection<Question> Questions { get; set; } = null!;
    }
}
