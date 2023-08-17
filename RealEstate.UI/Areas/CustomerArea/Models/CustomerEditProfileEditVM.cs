namespace RealEstate.UI.Areas.CustomerArea.Models
{
    public class CustomerEditProfileEditVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}
