using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Model
{
    public interface ISearchEngine
    {
        Model.ISearchEngineSite SearchEngineSite { get; }
        SearchEngineResult SearchAndGetTotalResults(string keywordSearch);
    }
}
