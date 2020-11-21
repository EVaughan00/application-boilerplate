using System.Collections.Generic;
using BuildingBlocks.SeedWork;
using AuthResource.Domain.Aggregates;

namespace AuthResource.Infrastructure
{
    public interface IUserRepository : IRepository<User>
    {
        void Create(User User);
        List<User> GetAll();
        User GetById(string id);
        void Update(User user);       
    }    
}