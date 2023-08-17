using Copreter.Domain.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copreter.Domain.Service.Contracts.Interfaces
{
    public interface IEstadoTrabajadorService
    {
        Task<IEnumerable<TEstadoTrabajador>> ListarAsync();
    }
}
