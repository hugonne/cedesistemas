using System;
using System.ComponentModel.DataAnnotations;

namespace Cedesistemas.WheresMyStuff.WebApi.Dtos
{
    public class RegisterDto
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
