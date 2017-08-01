using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Model
{
    public class InputSearchResult
    {
        public String KeyWord { get; set; }
        public List<SearchEngineResult> ItemResults { get; set; } = new List<SearchEngineResult>();
    }
}
