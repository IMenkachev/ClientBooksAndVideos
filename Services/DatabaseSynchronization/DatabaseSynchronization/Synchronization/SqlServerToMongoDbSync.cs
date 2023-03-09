using DatabaseSynchronization.Models;
using MongoDB.Driver;
using System.Data.SqlClient;

namespace DatabaseSynchronization.Synchronization
{
    public class SqlServerToMongoDbSync
    {
        private const string mssql_connection_string = "Server=localhost;Database=BooksAndVideosDb;User Id=sa;Password=ImI12345678;Encrypt=False;";
        private const string mongo_connection_string = "mongodb://localhost:27017";

        public static async void Sync()
        {
            List<string> tableNames = new List<string>() { "Customers", "Memberships", "Products" };

            SqlConnection mssqlConnection = new SqlConnection(mssql_connection_string);
            mssqlConnection.Open();

            MongoClient mongoClient = new MongoClient(mongo_connection_string);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("BooksAndVideosMongoDb");

            foreach (string tableName in tableNames)
            {
                SyncTables(tableName, mssqlConnection, mongoDatabase);
            }

            mssqlConnection.Close();
        }

        private static void SyncTables(string tableName, SqlConnection mssqlConnection, IMongoDatabase mongoDatabase)
        {
            string sqlQuery = "SELECT * FROM " + tableName;
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, mssqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (tableName is "Customers")
            {
                IMongoCollection<CustomerDto> customerCollection = mongoDatabase.GetCollection<CustomerDto>(tableName);

                bool existCustomer = customerCollection.Find(c => true).Any();
                if (!existCustomer)
                {
                    List<CustomerDto> customersList = new List<CustomerDto>();

                    while (sqlDataReader.Read())
                    {
                        customersList.Add(new CustomerDto
                        {
                            Id = sqlDataReader.GetGuid(0),
                            FirstName = sqlDataReader.GetString(1),
                            LastName = sqlDataReader.GetString(2)
                        });
                    }

                    sqlDataReader.Close();
                    customerCollection.InsertMany(customersList);
                }
            }

            if (tableName is "Memberships")
            {
                IMongoCollection<MembershipDto> membershipCollection = mongoDatabase.GetCollection<MembershipDto>(tableName);

                bool existMembership = membershipCollection.Find(c => true).Any();
                if (!existMembership)
                {
                    List<MembershipDto> membershipsList = new List<MembershipDto>();

                    while (sqlDataReader.Read())
                    {
                        membershipsList.Add(new MembershipDto
                        {
                            Id = sqlDataReader.GetGuid(0),
                            Name = sqlDataReader.GetString(1),
                            Price = sqlDataReader.GetDecimal(2),
                        });
                    }

                    sqlDataReader.Close();
                    membershipCollection.InsertMany(membershipsList);
                }

            }

            if (tableName is "Products")
            {
                IMongoCollection<ProductDto> productCollection = mongoDatabase.GetCollection<ProductDto>(tableName);

                bool existProduct = productCollection.Find(c => true).Any();
                if (!existProduct)
                {
                    List<ProductDto> productsList = new List<ProductDto>();

                    while (sqlDataReader.Read())
                    {
                        int sizeInMb;
                        if (sqlDataReader.IsDBNull(6))
                            sizeInMb = 0;
                        else
                            sizeInMb = sqlDataReader.GetInt32(6);


                        int quantity;
                        if (sqlDataReader.IsDBNull(7))
                            quantity = 0;
                        else
                            quantity = sqlDataReader.GetInt32(7);


                        productsList.Add(new ProductDto
                        {
                            Id = sqlDataReader.GetGuid(0),
                            Name = sqlDataReader.GetString(1),
                            ProductType = sqlDataReader.GetInt32(2),
                            Description = sqlDataReader.GetString(3),
                            Price = sqlDataReader.GetDecimal(4),
                            Discriminator = sqlDataReader.GetString(5),
                            SizeInMb = sizeInMb,
                            Quantity = quantity,
                        });
                    }

                    sqlDataReader.Close();
                    productCollection.InsertMany(productsList);
                }
            }

            sqlDataReader.Close();
        }
    }
}
