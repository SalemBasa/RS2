using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class QuizzesService : BaseService<Quiz, QuizDto, QuizUpsertDto, QuizzesSearchObject, IQuizzesRepository>, IQuizzesService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public QuizzesService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<QuizUpsertDto> validator, DatabaseContext databaseContext) : base(mapper, unitOfWork, validator)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async override Task<QuizDto> AddAsync(QuizUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var quiz = new Quiz
            {
                Title = dto.Title,
                Description = dto.Description,
                Questions = new List<Question>()
            };

            _databaseContext.Add(quiz);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            foreach (var questionDto in dto.Questions)
            {
                var question = new Question
                {
                    Content = questionDto.Content,
                    Points = questionDto.Points,
                    Answers = new List<Answer>(),
                    QuizId = quiz.Id
                };
                

                _databaseContext.Add(question);
                await _databaseContext.SaveChangesAsync(cancellationToken);

                foreach (var answerDto in questionDto.Answers)
                {
                    var answer = new Answer
                    {
                        Content = answerDto.Content,
                        IsTrue = answerDto.IsTrue,
                        QuestionId = question.Id
                    };
                    _databaseContext.Add(answer);
                }
            }

            await _databaseContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<QuizDto>(quiz);
        }

        public async Task<int> ProcessQuizSubmission(QuizSubmissionDto dto, CancellationToken cancellationToken = default)
        {
            var quiz = await _databaseContext.Quizzes
                                             .Include(q => q.Questions)
                                             .ThenInclude(q => q.Answers)
                                             .FirstOrDefaultAsync(q => q.Id == dto.QuizId, cancellationToken);

            if (quiz == null)
            {
                throw new Exception("Quiz not found");
            }

            int userScore = 0;

            foreach (var userAnswerId in dto.UserAnswerIds)
            {
                var question = quiz.Questions.FirstOrDefault(q => q.Answers.Any(a => a.Id == userAnswerId));

                if (question != null)
                {
                    var correctAnswer = question.Answers.FirstOrDefault(a => a.IsTrue);

                    if (correctAnswer != null && correctAnswer.Id == userAnswerId)
                    {
                        userScore += question.Points;
                    }
                }
            }

            var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId, cancellationToken);

            if (user != null)
            {
                user.Balance += userScore;
            }

            var reward = new Reward
            {
                UserId = dto.UserId,
                QuizId = dto.QuizId,
                Score = userScore,
                MoneyEarned = userScore
            };

            _databaseContext.Rewards.Add(reward);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return userScore;
        }

    }
}

