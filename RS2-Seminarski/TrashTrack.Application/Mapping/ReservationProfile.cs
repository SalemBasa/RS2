using TrashTrack.Core;

namespace TrashTrack.Application.Mapping;

public class ReservationProfile : BaseProfile
{
	public ReservationProfile()
	{
		CreateMap<ReservationDto, Reservation>().ReverseMap();

		CreateMap<ReservationUpsertDto, Reservation>();
	}
}
