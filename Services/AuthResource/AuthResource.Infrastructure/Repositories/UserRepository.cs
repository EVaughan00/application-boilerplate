using Microsoft.Extensions.Logging;
using AuthResource.Domain.Aggregates;
using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using System.Collections.Generic;
using System;

namespace AuthResource.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private ILogger<UserRepository> _logger;
        private IDbCollection<User> _users;
        public static string CollectionName = "Users";

        public UserRepository(ILoggerFactory logger, IDatabaseContext context)
        {
            _logger = logger.CreateLogger<UserRepository>();
            _users = context.GetCollection<User>(CollectionName);
        }

        public void Create(User entity)
        {
            _users.InsertOne(entity);
            _logger.LogInformation($"User {entity.Username} inserted in database"); 
        }

        public List<User> GetAll() 
        {
            var result = _users.FindAll();

            if (result == null) 
            {
                _logger.LogInformation($"Non-existant user retrieval attempted");
            }

            _logger.LogInformation($"Users retrieved from database");
            return result;
        }

        public User GetById(string id) 
        {
            var result = _users.FindOne(e => e.Username.Equals(id));

            if (result == null) 
            {
                _logger.LogInformation($"Non-existant user retrieval attempted");
                throw new System.Exception("User not found");
            }

            _logger.LogInformation($"user [{id}] retrieved from database");
            return result;
        }

        public void Update(User user)
        {
            var existing = _users.FindOne(u => u.Username == user.Username);
            var duplicate = _users.FindOne(u => u.Email == user.Email);

            if (existing == null)
            {
                throw new Exception($"No user exists to update");
            }

            _users.UpdateOne(user);
        }
    }
}