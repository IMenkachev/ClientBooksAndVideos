using CustomerCommands.Domain.Entities;

namespace CustomerCommands.Infrastructure.Persistence
{
    public class CustomerContextSeed
    {
        public static async Task SeedAsync(CustomerContext customerContext)
        {
            if (!customerContext.Customers.Any())
            {
                customerContext.Customers.AddRange(SeedCustomersList());
                await customerContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Customer> SeedCustomersList()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    UserName= "admin1",
                    FirstName = "John",
                    LastName = "Doe",
                    Age= 30,
                    Address = "21 2nd Street",
                    EmailAddress = "example@gmail.com",
                    Country = "USA",
                    City = "New York"
                },
                new Customer()
                {
                    UserName = "admin2",
                    FirstName = "Mike",
                    LastName = "Smith",
                    Age= 35,
                    Address = "29 12nd Street",
                    EmailAddress = "example2@gmail.com",
                    Country = "USA",
                    City = "Chicago"
                },
                new Customer()
                {

                    UserName = "admin3",
                    FirstName = "Charly",
                    LastName = "Parker",
                    Age= 39,
                    Address = "15 22nd Street",
                    EmailAddress = "example3@gmail.com",
                    Country = "USA",
                    City = "Haway"
                },
                new Customer()
                {
                    UserName = "admin4",
                    FirstName = "Alan",
                    LastName = "Parker",
                    Age= 29,
                    Address = "13 Baker Street",
                    EmailAddress = "example4@gmail.com",
                    Country = "USA",
                    City = "Washington DC"
                },
                new Customer()
                {
                    UserName = "admin5",
                    FirstName = "Jake",
                    LastName = "Hoper",
                    Age= 20,
                    Address = "33 Harlem Street",
                    EmailAddress = "example5@gmail.com",
                    Country = "USA",
                    City = "New York"
                }
            };
        }
    }
}
