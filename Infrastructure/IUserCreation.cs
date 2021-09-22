using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure
{
    public interface IUserCreation
    {
        List<User> GetAllUsers();
        Task<bool> CreateUser(User user);
    }
}