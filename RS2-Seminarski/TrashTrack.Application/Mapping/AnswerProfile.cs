using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class AnswerProfile : BaseProfile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerDto, Answer>().ReverseMap();

            CreateMap<AnswerUpsertDto, Answer>().ReverseMap();
        }
    }
}
