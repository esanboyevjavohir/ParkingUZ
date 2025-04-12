﻿using ParkingUZ.Core.Enums;

namespace ParkingUZ.Application.Models.User
{
    public class LoginUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel : BaseResponseModel
    {
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
