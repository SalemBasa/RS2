using TrashTrack.Api;
using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class UserProfile : BaseProfile
    {
        public UserProfile()
        {
            CreateMap<AccessSignUpModel, UserUpsertDto>();
            
            CreateMap<AccessSignUpModel, User>().ReverseMap();

            CreateMap<UserUpsertModel, UserUpsertDto>();

            CreateMap<UserUpdateModel, UserUpsertDto>();
        }
    }
}
