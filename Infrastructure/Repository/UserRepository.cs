using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Persistence;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if(existingUser != null)
                {
                    existingUser.Email = entity.Email;
                    existingUser.Name = entity.Name;

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var existingUser = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(existingUser != null)
                {
                    _dbSet.Remove(existingUser);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(UserRepository));
                return false;
            }
        }
    }
}