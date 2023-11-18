using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class FeedbackProfile : BaseProfile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedBackDto, Feedback>().ReverseMap();

            CreateMap<FeedbackUpsertDto, Feedback>();
        }
    }
}
