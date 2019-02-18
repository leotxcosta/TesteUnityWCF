using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class RepositoryA : IRepositoryA
    {
        private IUnitOfWork _unitOfWork;
        private Guid _guid;

        public RepositoryA()
        {
            if (_guid == Guid.Empty)
                _guid = Guid.NewGuid();
        }
        public RepositoryA(IUnitOfWork unitOfWork) : this()
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }
            
        public List<string> GetDataA()
        {
            var ret = _unitOfWork.GetData();
            ret.Add("Repo A - " + _guid.ToString());
            return ret;
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
        }
    }
}
