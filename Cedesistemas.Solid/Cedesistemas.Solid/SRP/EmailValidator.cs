namespace Cedesistemas.Solid.SRP
{
    public class EmailValidator
    {
        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
    }
}
