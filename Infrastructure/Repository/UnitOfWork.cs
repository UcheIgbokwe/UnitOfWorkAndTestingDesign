using System;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly ILogger _logger;
        private readonly TDbContext _dbContext;
        protected readonly IServiceProvider _serviceProvider;

        public UnitOfWork(TDbContext dbContext, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");
            _serviceProvider = serviceProvider;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var repositoryType = typeof(GenericRepository<TDbContext, T>);
            return (IGenericRepository<T>)_serviceProvider.GetService(repositoryType);
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}