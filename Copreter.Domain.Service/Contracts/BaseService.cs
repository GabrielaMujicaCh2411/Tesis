using Copreter.Domain.Model.Repository.Interfaces;

namespace Copreter.Domain.Service.Contracts
{
    public class BaseService
    {
        #region Fields

        public readonly ICopreterData _data;

        public string CurrentUser { get; set; }

        #endregion

        public BaseService(ICopreterData data)
        {
            this._data = data;
            this.CurrentUser = "Mx";
        }
    }
}
