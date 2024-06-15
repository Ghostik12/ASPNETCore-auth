using System.Net.Mail;

namespace AuthenticationService
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = IsFromRussia(user.Email);
        }

        public string GetFullName(string? firstName, string? lastName)
        {
            return FullName = String.Concat(firstName, " ", lastName); ;
        }

        public bool IsFromRussia(string? email) 
        {
            MailAddress mail = new MailAddress(email);

            if (mail.Host.Contains(".ru"))
                return true;
            return false;
        }
    }
}
