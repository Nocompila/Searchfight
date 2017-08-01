using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Model
{
    public class SearchResult
    {
        public List<InputSearchResult> InputsSearchResults { get; set; } = new List<InputSearchResult>();
        public List<SearchEngineResult> SearchEngineResults { get; set; } = new List<SearchEngineResult>();
        public String TotalWinner { get; set; }
    }
}
