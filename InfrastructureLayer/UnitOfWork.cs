using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
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
    public class UnitOfWork : IUnitOfWork
    {
        private Guid _guid;

        private List<AllocatedData> _listAllocatedData;
        private List<AllocatedData> _listAllocatedData2;
        public UnitOfWork()
        {
            if (_guid == Guid.Empty)
                _guid = Guid.NewGuid();
        }
        public List<string> GetData()
        {
            if(_listAllocatedData == null)
            {
                _listAllocatedData = new List<AllocatedData>();
                _listAllocatedData2 = new List<AllocatedData>();
                for (int i = 0; i < 3000000; i++)
                {
                    _listAllocatedData.Add(new AllocatedData(i, i.ToString() + " - " + _guid.ToString()));
                    _listAllocatedData2.Add(new AllocatedData(i, i.ToString() + " # " + _guid.ToString()));
                }
            }
            
            var lista = new List<string>();
            lista.Add("UnitOfWork - " + _guid.ToString());
            return lista;
        }

        public void Dispose()
        {
            //_listAllocatedData.Clear();
            //_listAllocatedData2.Clear();
        }
    }
}
