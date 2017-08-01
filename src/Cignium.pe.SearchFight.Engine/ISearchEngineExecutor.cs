using System.Collections.Generic;
using Cignium.pe.SearchFight.Model;

namespace Cignium.pe.SearchFight.Engine
{
    public interface ISearchEngineExecutor
    {
        string ExecuteSearch(string[] keyWords);
        List<ISearchEngine> SearchEngines();
    }
}