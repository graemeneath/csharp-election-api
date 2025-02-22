using election_api.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace election_api.Service
{
    public class ResultService
    {
        private Dictionary<int, ConstituencyResult> _results;

        public ResultService() {
            _results = new Dictionary<int, ConstituencyResult>();
        }

        public ConstituencyResult GetResult(int id)
        {
            return _results[id];
        }

        public void NewResult(ConstituencyResult result) {
            _results.Add(result.Id, result);
        }

        public Dictionary<int, ConstituencyResult> GetAll()
        {
            return _results;
        }

        public void Reset() { 
            _results.Clear();
        }
    }
}
