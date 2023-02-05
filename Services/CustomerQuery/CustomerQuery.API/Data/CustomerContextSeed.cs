using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Data
{
    public class CustomerContextSeed
    {
        public static void SeedData(IMongoCollection<Customer> customerCollection)
        {

            bool existCustomert = customerCollection.Find(p => true).Any();
            if (!existCustomert)
            {
                customerCollection.InsertManyAsync(GetCustomerCollection());
            }

        }

        private static IEnumerable<Customer> GetCustomerCollection()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
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
                    Id = 2,
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
                    Id = 3,
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
                    Id = 4,
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
                    Id = 5,
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
