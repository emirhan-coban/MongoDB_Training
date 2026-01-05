using CSharpEgitimKampi601.Entities;
using MongoDB.Bson;

namespace CSharpEgitimKampi601.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            // Müşteri ekleme işlemleri burada yapılacak
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                { "CustomerName", customer.CustomerName },
                { "CustomerSurname", customer.CustomerSurname },
                { "CustomerCity", customer.CustomerCity },
                { "CustomerBalance", customer.CustomerBalance },
                { "CustomerShoppingCount", customer.CustomerShoppingCount }
            };
            customerCollection.InsertOne(document);
        }
        public void UpdateCustomer()
        {
            // Müşteri güncelleme işlemleri burada yapılacak
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
        }
        public void DeleteCustomer()
        {
            // Müşteri silme işlemleri burada yapılacak
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
        }
    }
}
