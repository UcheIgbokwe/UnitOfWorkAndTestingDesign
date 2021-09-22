using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        
    }
}