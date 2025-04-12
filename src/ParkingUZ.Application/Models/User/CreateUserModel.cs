using ParkingUZ.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ParkingUZ.Application.Models.User
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "Foydalanuvchi nomini kiritish shart")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Ism uzunligi kamida 2 ta va maksimal 15 ta bo'lishi kerak")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Ism faqat harflar va bo'sh joylardan iborat bo'lishi mumkin")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email manzilini kiritish shart")]
        [EmailAddress(ErrorMessage = "Email manzil noto'g'ri formatda")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Foydalanuvchi nomerini kiritishi shart")]
        [StringLength(15, MinimumLength = 13, ErrorMessage = "Nomer uzunligi kamida 13 ta va maksimal 15 ta bo'lishi kerak")]
        [RegularExpression(@"^\+[0-9]*$", ErrorMessage = "Nomer '+' belgisi va faqat raqamlardan iborat bo‘lishi kerak")]
        public string? PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        [DefaultValue("")]
        public string? Password { get; set; }
    }

    public class CreateUserResponseModel : BaseResponseModel { }
}
