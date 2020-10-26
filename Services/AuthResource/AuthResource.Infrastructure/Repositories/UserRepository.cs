using Microsoft.Extensions.Logging;
using AuthResource.Domain.Aggregates;
using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using System.Collections.Generic;

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

        // public user GetByEmail(string email) 
        // {
        //     email = email.ToLower();
        //     var result = _users.FindOne(u => u.Email.Equals(email));

        //     if (result == null) 
        //     {
        //         _logger.LogInformation($"Non-existant user [{email}] retrieval attempted");
        //         var ex = new ApiException($"That username and / or password are incorrect");
        //         ex.AddError("password", ex.Message);

        //         throw ex;
        //     }

        //     _logger.LogInformation($"user [{email}] retrieved from database");
        //     return result;
        // }

        // public void Update(user user)
        // {
        //     var existing = _users.FindOne(u => u.Id == user.Id);
        //     var duplicate = _users.FindOne(u => u.Email.Equals(user.Email.Address));

        //     if (existing == null)
        //     {
        //         throw new IdentityInfrastructureException($"No user exists to update");
        //     }

        //     if (duplicate != null && !existing.Equals(duplicate))  
        //     {                
        //         var ex = new ApiException($"That email is already taken");
        //         ex.AddError("email", ex.Message);

        //         throw ex;
        //     }

        //     _users.UpdateOne(user);
        // }

        // public void Delete(string email)
        // {
        //     try {
        //         GetByEmail(email);

        //         _logger.LogInformation($"user [{email}] removed from database");
        //         _users.DeleteOne(u => u.Email.Address == email);
        //     } catch {
        //         _logger.LogInformation($"Non-existant user [{email}] deletion attempted");
        //         throw new IdentityInfrastructureException($"No user with an email: \"{email}\" exists to delete");
        //     }
        // }
    }
}