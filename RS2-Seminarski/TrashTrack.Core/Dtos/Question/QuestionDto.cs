﻿namespace TrashTrack.Core
{
    public class QuestionDto : BaseDto
    {
        public string Content { get; set; } = null!;
        public int Points { get; set; }

        public int QuizId { get; set; }
        public QuizDto Quiz { get; set; } = null!;

        public ICollection<AnswerDto> Answers { get; set; } = null!;
    }
}
