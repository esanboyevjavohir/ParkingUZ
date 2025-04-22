using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingUZ.Core.Entities;
using ParkingUZ.Core.Enums;
using System.Security.Cryptography;
using System.Text;

namespace ParkingUZ.DataAccess.Persistence
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.PasswordHash)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(a => a.Salt)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(a => a.Name)
                .HasMaxLength(1000)
                .IsRequired();

            builder.HasData(GenerateUsers());
        }

        public string Encrypt(string password, string salt)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                iterations: 1000,
                hashAlgorithm: HashAlgorithmName.SHA256);

            return Convert.ToBase64String(algorithm.GetBytes(32));
        }

        string salt = "5bd421f2-1e10-4dd9-81ff-e26c83e33b2f";

        private List<User> GenerateUsers() => new()
        {
            new User
            {
                Id = Guid.Parse("bc56836e-0345-4f01-a883-47f39e32e079"),
                Name = "Adminjon Adminov",
                Role = UserRole.Admin,
                PhoneNumber = "+999999999111",
                Email = "adminjon@gmail.com",
                PasswordHash = Encrypt("web@1234", salt),
                Salt = salt
            }
        };
    }
}
