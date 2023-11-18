using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class QuizProfile : BaseProfile
    {
        public QuizProfile()
        {
            CreateMap<QuizDto, Quiz>().ReverseMap();

            CreateMap<QuizUpsertDto, Quiz>().ReverseMap();
        }
    }
}
