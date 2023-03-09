using DatabaseSynchronization.Models;
using MongoDB.Driver;
using System.Data.SqlClient;

namespace DatabaseSynchronization.Synchronization
{
    public class MongoDbToSqlServerSync
    {
        private const string mongo_connection_string = "mongodb://localhost:27017";
        private const string mssql_connection_string = "Server=localhost;Database=BooksAndVideosDb;User Id=sa;Password=ImI12345678;Encrypt=False;";

        public static async void Sync()
        {
            List<string> tableNames = new List<string>() { "Customers", "Memberships", "Products" };

            MongoClient mongoClient = new MongoClient(mongo_connection_string);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("BooksAndVideosMongoDb");

            SqlConnection mssqlConnection = new SqlConnection(mssql_connection_string);
            mssqlConnection.Open();

            foreach (string tableName in tableNames)
            {
                SyncTables(tableName, mssqlConnection, mongoDatabase);
            }

            mssqlConnection.Close();
        }

        private static void SyncTables(string tableName, SqlConnection mssqlConnection, IMongoDatabase mongoDatabase)
        {
            if (tableName is "Customers")
            {
                var customerCollection = mongoDatabase.GetCollection<CustomerDto>(tableName);

                bool existCustomer = customerCollection.Find(c => true).Any();
                if (!existCustomer)
                {
                    var customerDocuments = customerCollection.Find<CustomerDto>(Builders<CustomerDto>.Filter.Empty).ToList();

                    foreach (var customerDocument in customerDocuments)
                    {
                        var sqlCommand = new SqlCommand(
                        $"INSERT INTO {tableName} (Id, FirstName, LastName) VALUES (@Id, @FirstName, @LastName)", mssqlConnection);

                        sqlCommand.Parameters.AddWithValue("@Id", customerDocument.Id);
                        sqlCommand.Parameters.AddWithValue("@FirstName", customerDocument.FirstName);
                        sqlCommand.Parameters.AddWithValue("@LastName", customerDocument.LastName);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }

            if (tableName is "Memberships")
            {
                var membershipCollection = mongoDatabase.GetCollection<MembershipDto>(tableName);

                bool existMembership = membershipCollection.Find(c => true).Any();
                if (!existMembership)
                {
                    var membershipDocuments = membershipCollection.Find<MembershipDto>(Builders<MembershipDto>.Filter.Empty).ToList();

                    foreach (var membershipDocument in membershipDocuments)
                    {
                        var sqlCommand = new SqlCommand(
                        $"INSERT INTO {tableName} (Id, Name, Price) VALUES (@Id, @Name, @Price)", mssqlConnection);

                        sqlCommand.Parameters.AddWithValue("@Id", membershipDocument.Id);
                        sqlCommand.Parameters.AddWithValue("@Name", membershipDocument.Name);
                        sqlCommand.Parameters.AddWithValue("@Price", membershipDocument.Price);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }

            if (tableName is "Products")
            {
                var productsCollection = mongoDatabase.GetCollection<ProductDto>(tableName);

                bool existProduct = productsCollection.Find(c => true).Any();
                if (!existProduct)
                {
                    var productsDocuments = productsCollection.Find<ProductDto>(Builders<ProductDto>.Filter.Empty).ToList();

                    foreach (var productDocument in productsDocuments)
                    {
                        var sqlCommand = new SqlCommand(
                             $"INSERT INTO {tableName} " +
                             $"(Id, Name, Description, Price, Discriminator, ProductType, SizeInMb, Quantity) " +
                             $"VALUES (@Id, @Name, @Description, @Price, @Discriminator, @ProductType, @SizeInMb, @Quantity)",
                        mssqlConnection);

                        sqlCommand.Parameters.AddWithValue("@Id", productDocument.Id);
                        sqlCommand.Parameters.AddWithValue("@Name", productDocument.Name);
                        sqlCommand.Parameters.AddWithValue("@Description", productDocument.Description);
                        sqlCommand.Parameters.AddWithValue("@Price", productDocument.Price);
                        sqlCommand.Parameters.AddWithValue("@Discriminator", productDocument.Discriminator);
                        sqlCommand.Parameters.AddWithValue("@ProductType", productDocument.ProductType);
                        sqlCommand.Parameters.AddWithValue("@SizeInMb", productDocument.SizeInMb);
                        sqlCommand.Parameters.AddWithValue("@Quantity", productDocument.Quantity);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
