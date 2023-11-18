namespace TrashTrack.Core;

public class QuizSubmissionDto
{
	public int UserId { get; set; }
	public int QuizId { get; set; }
	public List<int> UserAnswerIds { get; set; } = default!;
}
