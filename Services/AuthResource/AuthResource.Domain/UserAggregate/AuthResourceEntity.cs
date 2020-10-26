using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthResource.Domain.Aggregates
{
    public class User : Entity, IAggregateRoot
    {

        [BsonElement("Username")]
        public string Username{ get; private set; }

        [BsonElement("Password")]
        public string Password { get; private set; }

        [BsonElement("Email")]
        public string Email { get; private set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        
    }
}