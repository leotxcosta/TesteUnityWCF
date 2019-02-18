using ApplicationLayer;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
//using TesteUnityWCF.Unity;

namespace TesteUnityWCF
{
    class AllocatedData
    {
        public int Id { private set; get; }
        public string Data { private set; get; }
        public AllocatedData(int id, string data)
        {
            Id = id;
            Data = data;
        }
    }

    //[UnityInstanceProviderServiceBehavior()]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        private IAppServiceTest _appService;
        private Guid _guid;
        private List<AllocatedData> _listAllocatedData;
        private List<AllocatedData> _listAllocatedData2;

        public Service1()
        {
            if (_guid == Guid.Empty)
                _guid = Guid.NewGuid();
        }
        public Service1(IAppServiceTest appService) : this()
        {
            if (appService == null)
                throw new ArgumentNullException("appservice");

            _appService = appService;
        }
        public string[] GetData()
        {
            /*if (_listAllocatedData == null)
            {
                _listAllocatedData = new List<AllocatedData>();
                _listAllocatedData2 = new List<AllocatedData>();
                for (int i = 0; i < 3000000; i++)
                {
                    _listAllocatedData.Add(new AllocatedData(i, i.ToString() + " - " + _guid.ToString()));
                    _listAllocatedData2.Add(new AllocatedData(i, i.ToString() + " # " + _guid.ToString()));
                }
            }*/

            var ret = new List<string>();
            ret.Add("Service - " + _guid.ToString());
            ret.AddRange(_appService.GetData());

            
            //var uw = Container.Current.Resolve(typeof(Common.IUnitOfWork)) as Common.IUnitOfWork;

            //ret.Add("resolve unit of work");
            //ret.AddRange(uw.GetData());

            return ret.ToArray();
        }

        public void Dispose()
        {
            //_listAllocatedData = null;
            //_listAllocatedData2 = null;
            //_appService.Dispose();
            _appService = null;
        }
    }
}
