using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure
{
    public class UserCreation : IUserCreation
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserCreation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<User> GetAllUsers()
        {
            return _unitOfWork.Repository<User>().GetAll();
        }

        public async Task<bool> CreateUser(User user)
        {
            _unitOfWork.Repository<User>().Add(user);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}