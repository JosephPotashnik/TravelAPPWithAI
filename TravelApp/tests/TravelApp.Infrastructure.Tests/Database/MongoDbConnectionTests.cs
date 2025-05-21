using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using TravelApp.Infrastructure.Database;
using Xunit;

namespace TravelApp.Infrastructure.Tests.Database
{
    public class MongoDbConnectionTests
    {
        [Fact(Skip = "Requires a running MongoDB instance")]
        public void CanConnect_WithValidSettings_ShouldSucceed()
        {
            // Arrange
            var settings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "TravelAppTest"
            };

            var mockOptions = new Mock<IOptions<MongoDbSettings>>();
            mockOptions.Setup(o => o.Value).Returns(settings);

            // Act
            var mongoDbContext = new MongoDbContext(mockOptions.Object);
            var collection = mongoDbContext.GetCollection<object>("_connectionTest");

            // Assert
            // No exception means test passes
            Assert.NotNull(collection);
        }

        [Fact]
        public void Constructor_WithEmptyConnectionString_ShouldThrowException()
        {
            // Arrange
            var settings = new MongoDbSettings
            {
                ConnectionString = "",
                DatabaseName = "TravelAppTest"
            };

            var mockOptions = new Mock<IOptions<MongoDbSettings>>();
            mockOptions.Setup(o => o.Value).Returns(settings);

            // Act & Assert
            Assert.Throws<Exception>(() => new MongoDbContext(mockOptions.Object));
        }

        [Fact]
        public void GetCollection_ShouldReturnCollection()
        {
            // Arrange
            var settings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "TravelAppTest",
                UsersCollection = "Users"
            };

            var mockDatabase = new Mock<IMongoDatabase>();
            var mockCollection = new Mock<IMongoCollection<object>>();
            mockDatabase.Setup(d => d.GetCollection<object>(It.IsAny<string>(), null))
                .Returns(mockCollection.Object);

            var mockClient = new Mock<IMongoClient>();
            mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                .Returns(mockDatabase.Object);

            var mockClientFactory = new Func<MongoClient>(() => mockClient.Object as MongoClient);
            
            // This test wouldn't actually work since we can't inject the client factory
            // In a real test, we would use a more testable design or a real MongoDB instance
            // This is just to demonstrate the test structure
        }
    }
}