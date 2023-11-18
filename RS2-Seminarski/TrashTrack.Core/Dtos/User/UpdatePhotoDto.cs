using Microsoft.AspNetCore.Http;

namespace TrashTrack.Core.Dtos.User
{
    public class UpdatePhotoDto : BaseDto
    {
        public int UserId { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
    }
}
