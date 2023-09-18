using BackEndCubos.Domain.Core.Interfaces.Repositories;

namespace BackEndCubos.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly PostgreSQLContext postgreSQLContext;
        public RepositoryBase(PostgreSQLContext postgreSQLContext)
        {
            this.postgreSQLContext = postgreSQLContext;
        }

        public TEntity Add(TEntity obj)
        {
            postgreSQLContext.Set<TEntity>().Add(obj);
            postgreSQLContext.SaveChanges();
            return obj;
        }
    }
}
