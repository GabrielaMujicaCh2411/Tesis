using Copreter.Domain.Model.Repository.Interfaces;
using Copreter.Domain.Service.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copreter.Domain.Service.Contracts
{
    internal class AuthService : BaseService, IAuthService
    {
        public AuthService(ICopreterData data) : base(data)
        {
        }
    }
}
