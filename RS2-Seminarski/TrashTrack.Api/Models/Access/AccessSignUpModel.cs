﻿using TrashTrack.Core;

namespace TrashTrack.Api
{
    public class AccessSignUpModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
        public string? ProfilePhoto { get; set; }
    }
}
