using System;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IUserRepository Users { get; private set; }
        private readonly ILogger _logger;
        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(dbContext, _logger);

        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}