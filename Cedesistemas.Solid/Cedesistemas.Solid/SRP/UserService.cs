using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.Solid.SRP
{
    public class UserService
    {
        private readonly EmailValidator _validator;
        private readonly EmailSender _sender;

        public UserService(EmailValidator validator, EmailSender sender)
        {
            string a = "Hola Mundo";
            a = a.ToSentence();

            _validator = validator;
            _sender = sender;
        }

        public void Register(string email, string password)
        {
            if (!_validator.ValidateEmail(email))
                throw new ValidationException("Email is not an email");

            //var user = new User(email, password);

            _sender.SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject = "Hello foo" });
        }


    }

    public static class StringExtensions
    {
        public static string ToSentence(this string a)
        {
            return a + ".";
        }
    }
}
