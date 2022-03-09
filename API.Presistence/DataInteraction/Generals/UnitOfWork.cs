
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace API.Presistence
{
    using API.Presistence.DataAccess.DataAccess;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Threading.Tasks;
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable _repositories;
        private Hashtable _repositoriesWithKey;
        private ApiDbContext _dbContext;


        private readonly ILoggerFactory _loggerFactory;

        public UnitOfWork(ApiDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _loggerFactory = loggerFactory;

        }

        public IDataAccess<TEntity> DataAccess<TEntity, Tkey>()
            where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            string type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                //object repositoryInstance = Tools.CreateInstantOf<IDataAccess<TEntity>>(
                //    new Type[] { typeof(SalaNoorDbContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

                //_repositories.Add(type, repositoryInstance);
            }

            return (IDataAccess<TEntity>)_repositories[type];
        }




     
        


        //public IDataAccess<TEntity, TKey> DataAccess<TEntity, TKey>()
        //    where TEntity : class
        //{
        //    if (_repositoriesWithKey == null)
        //    {
        //        _repositoriesWithKey = new Hashtable();
        //    }

        //    string type = typeof(TEntity).Name;

        //    if (!_repositoriesWithKey.ContainsKey(type))
        //    {

        //        object repositoryInstance = Tools.CreateInstantOf<DataAccess<TEntity, TKey>>(
        //            new Type[] { typeof(SalaNoorDbContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

        //        _repositoriesWithKey.Add(type, repositoryInstance);
        //    }

        //    return (IDataAccess<TEntity, TKey>)_repositoriesWithKey[type];
        //}











        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public void ResetContextState()
        {
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

      
    }
}
