using TrashTrack.Core;

namespace TrashTrack.Application
{
    public class UserProfile : BaseProfile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<User, UserSensitiveDto>();

            CreateMap<UserDto, UserUpsertDto>();

            CreateMap<UserUpsertDto, User>()
                .ForMember(u => u.Role, o => o.Condition(s => s.Role != null))
                  .ForMember(u => u.Balance, o => o.MapFrom(s => 0))
                  .ReverseMap();
        }
    }
}

