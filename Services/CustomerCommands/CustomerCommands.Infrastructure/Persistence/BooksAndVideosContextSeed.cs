using CustomerCommands.Domain.Customers;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Domain.Products;

namespace CustomerCommands.Infrastructure.Persistence
{
    public static class BooksAndVideosContextSeed
    {
        public static async Task SeedAsync(BooksAndVideosContext context)
        {
            SeedCustomers(context);
            SeedProducts(context);
            SeedMemberships(context);

            await context.SaveChangesAsync();
        }

        #region Memberships
        private static void SeedMemberships(BooksAndVideosContext context)
        {
            if (!context.Memberships!.Any())
            {
                context.Memberships!.Add(new Membership(
                    id: Guid.NewGuid(),
                    name: "Video Club",
                    price: 300m
                    ));

                context.Memberships!.Add(new Membership(
                    id: Guid.NewGuid(),
                    name: "Book Club",
                    price: 200m
                    ));

                context.Memberships!.Add(new Membership(
                    id: Guid.NewGuid(),
                    name: "Premium Club",
                    price: 400m
                    ));
            }
        }
        #endregion

        #region Products
        private static void SeedProducts(BooksAndVideosContext context)
        {
            if (!context.Products!.Any()) 
            {
                context.Products!.Add(new PhysicalProduct(
                    id: Guid.NewGuid(),
                    name: "Minority Report",
                    productType: ProductType.Video,
                    description: "Action/Fantasy, 120 min, 2004",
                    price: 15m,
                    quantity: 5
                    ));

                context.Products!.Add(new PhysicalProduct(
                    id: Guid.NewGuid(),
                    name: "American Pie",
                    productType: ProductType.Video,
                    description: "Comedy, 120 min, 1999",
                    price: 10m,
                    quantity: 5
                    ));

                context.Products!.Add(new DigitalProduct(
                    id: Guid.NewGuid(),
                    name: "Shindler's List",
                    productType: ProductType.Video,
                    description: "Drama, 140 min, 1994",
                    price: 5m,
                    sizeInMb: 150
                    ));

                context.Products!.Add(new DigitalProduct(
                    id: Guid.NewGuid(),
                    name: "Jurasic Park",
                    productType: ProductType.Video,
                    description: "Fantasy, 120 min, 1994",
                    price: 9.90m,
                    sizeInMb: 120
                    ));

                context.Products!.Add(new PhysicalProduct(
                    id: Guid.NewGuid(),
                    name: "1984",
                    productType: ProductType.Book,
                    description: "Dystopian novel, 350 pgs, 1948",
                    price: 15.80m,
                    quantity: 5
                    ));

                context.Products!.Add(new PhysicalProduct(
                    id: Guid.NewGuid(),
                    name: "Think and Grow Rich",
                    productType: ProductType.Book,
                    description: "Personal development, 250 pgs, 1937",
                    price: 10.80m,
                    quantity: 5
                    ));

                context.Products!.Add(new DigitalProduct(
                    id: Guid.NewGuid(),
                    name: "The Law of Success",
                    productType: ProductType.Book,
                    description: "Personal development, 250 pgs, 1925",
                    price: 5.80m,
                    sizeInMb: 30
                    ));

                context.Products!.Add(new DigitalProduct(
                    id: Guid.NewGuid(),
                    name: "The Little Prince",
                    productType: ProductType.Book,
                    description: "Personal development, 40 pgs, 1943",
                    price: 4.80m,
                    sizeInMb: 10
                    ));
            }
        }
        #endregion

        #region Customers
        private static void SeedCustomers(BooksAndVideosContext context)
        {
            if (!context.Customers!.Any())
            {
                context.Customers!.Add(new Customer(
                    id: Guid.NewGuid(),
                    firstName: "John",
                    lastName: "Doe"));

                context.Customers!.Add(new Customer(
                    id: Guid.NewGuid(),
                    firstName: "Mike",
                    lastName: "Smith"));

                context.Customers!.Add(new Customer(
                    id: Guid.NewGuid(),
                    firstName: "Charly",
                    lastName: "Parker"));

                context.Customers!.Add(new Customer(
                    id: Guid.NewGuid(),
                    firstName: "Alan",
                    lastName: "Parker"));

                context.Customers!.Add(new Customer(
                    id: Guid.NewGuid(),
                    firstName: "Jake",
                    lastName: "Hoper"));
            }
        }
        #endregion
    }
}
