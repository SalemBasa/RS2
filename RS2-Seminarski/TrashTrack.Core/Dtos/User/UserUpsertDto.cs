﻿namespace TrashTrack.Core
{
    public class UserUpsertDto : BaseUpsertDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public Gender Gender { get; set; }
        public string? Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public Role? Role { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsActive { get; set; }
        public string? ProfilePhoto { get; set; }
    }
}
