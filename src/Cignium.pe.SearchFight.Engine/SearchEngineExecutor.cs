using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Engine
{
    public class SearchEngineExecutor
    {
        public String ExecuteSearch(String[] keyWords)
        {
            return new Printer.PrinterStringBuilder()
                .Print(new EngineSearchManager(SearchEngines())
                .Search(keyWords));
        }

        public List<Model.ISearchEngine> SearchEngines()
        {
            return new List<Model.ISearchEngine> {
                    new GoggleSearch.GoggleSearchEngine(),
                    new MSNSearch.MSNSearchEngine()
            };
        }
    }
}
