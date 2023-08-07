using Copreter.Domain.Model.DbModel;
using Shared.Business.Core.Infraestructure.Repositories.Interfaces;

namespace Copreter.Domain.Model.Repository.Interfaces
{
    public interface IRepository<TEntity> : IAsyncRepository<CopreterContext, TEntity> where TEntity : class
    {
    }
}
