using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Tests.FakeComponents
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; private set; }
        private readonly ILogger _logger;
        private readonly DataContext _dbContext;
        public FakeUnitOfWork(DataContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(dbContext, _logger);
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}