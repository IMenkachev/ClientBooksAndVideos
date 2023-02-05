using CustomerCommands.Domain.Common;

namespace CustomerCommands.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public void UpdateCustomer(int id, string userName, string firstName, string lastName, int age, string address,string emailAddress, string country, string city)
        {
            Id = id;
            UserName= userName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            EmailAddress = emailAddress;
            Country = country;
            City = city;
        }
    }
}
