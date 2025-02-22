using election_api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace election_api.Service
{
    public class ResourceService
    {
        public ResourceService() { }

        public ConstituencyResult? GetConstituencyResult(int i)
        {
            string? baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            baseDirectory = baseDirectory ?? throw new Exception("Could not determine base directory");
            string filepath = $"{baseDirectory}/Resources/sample-election-results/result{i:D3}.json";
            string json = File.ReadAllText(filepath);
            ConstituencyResult? result = JsonConvert.DeserializeObject<ConstituencyResult>(json);
            return result;
        }
    }
}
