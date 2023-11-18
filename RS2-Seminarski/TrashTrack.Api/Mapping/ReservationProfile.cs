using TrashTrack.Api.Models.Reservation;
using TrashTrack.Core;

namespace TrashTrack.Application;

public class ReservationProfile : BaseProfile
{
	public ReservationProfile()
	{
		CreateMap<ReservationUpdateModel, ReservationUpsertDto>();
	}
}
