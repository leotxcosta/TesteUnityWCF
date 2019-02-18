using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class AppServiceTest : IAppServiceTest
    {
        private IRepositoryA _repoA;
        private IRepositoryB _repoB;
        public AppServiceTest(IRepositoryA repoA, IRepositoryB repoB)
        {
            if (repoA == null)
                throw new ArgumentNullException("repoA");

            if (repoB == null)
                throw new ArgumentNullException("repoA");

            _repoA = repoA;
            _repoB = repoB;
        }
        public List<string> GetData()
        {
            var ret = new List<string>();

            ret.Add("REPO A");
            ret.AddRange(_repoA.GetDataA());
            ret.Add("REPO B");
            ret.AddRange(_repoB.GetDataB());

            return ret;
        }

        #region IDisposable Support
        public void Dispose()
        {
            _repoA.Dispose();
            _repoB.Dispose();
        }
        #endregion
    }
}
