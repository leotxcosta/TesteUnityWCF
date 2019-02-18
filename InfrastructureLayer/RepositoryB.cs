using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class RepositoryB : IRepositoryB
    {
        private IUnitOfWork _unitOfWork;
        private Guid _guid;

        public RepositoryB()
        {
            if (_guid == Guid.Empty)
                _guid = Guid.NewGuid();
        }
        public RepositoryB(IUnitOfWork unitOfWork) : this()
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
          
        }

        public List<string> GetDataB()
        {
            var ret = _unitOfWork.GetData();
            ret.Add("Repo B - " + _guid.ToString());
            return ret;
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
        }
    }
}
