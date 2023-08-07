using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Shared.Business.Core.Infraestructure.Repositories;

namespace Copreter.Domain.Model.Repository
{
    public class Repository<TEntity> : AsyncRespository<CopreterContext, TEntity>, IRepository<TEntity> where TEntity : class
    {
        public Repository(CopreterContext context) : base(context)
        {
        }

        public async Task<IDbContextTransaction> BeginTrans()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitTrans(IDbContextTransaction dbContextTransaction)
        {
            await dbContextTransaction.CommitAsync();
            await dbContextTransaction.DisposeAsync();
        }

        public async Task RollbackTrans(IDbContextTransaction dbContextTransaction)
        {
            await dbContextTransaction.RollbackAsync();
            await dbContextTransaction.DisposeAsync();
        }
    }
}