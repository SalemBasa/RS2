namespace TrashTrack.Api
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsActive { get; set; }
    }
}
