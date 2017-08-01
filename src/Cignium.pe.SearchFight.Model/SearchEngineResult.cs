using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Model
{
    public class SearchEngineResult
    {
        public ISearchEngineSite SearchEngineSite { get; set; }
        public Int64 TotalResults { get; set; }
        public String InputWinner { get; set; }
    }
}
