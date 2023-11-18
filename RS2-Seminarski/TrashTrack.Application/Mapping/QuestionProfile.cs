using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class QuestionProfile : BaseProfile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionDto, Question>().ReverseMap();

            CreateMap<QuestionUpsertDto, Question>().ReverseMap();
        }
    }
}
