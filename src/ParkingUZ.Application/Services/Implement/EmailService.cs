using ParkingUZ.Application.Services.Interface;
using System.Net.Mail;
using System.Net;

namespace ParkingUZ.Application.Services.Implement
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(string email, string otp)
        {
            try
            {
                var bussinessMail = "javohiresanboyev053@gmail.com";
                var pass = "zdie hwjw rtcj tspg";
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(bussinessMail, pass)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(bussinessMail),
                    Subject = "Verification Code",
                    Body = $"Dear {email}," +
                           "\nYou are using this email address to register on our website." +
                           $"\n\nYour verification code is {otp}." +
                           "\nPlease use it to complete your registration before it expires." +
                           "\n\nIf you didn't request this, please ignore this email." +
                           "\n\nThank you!",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
