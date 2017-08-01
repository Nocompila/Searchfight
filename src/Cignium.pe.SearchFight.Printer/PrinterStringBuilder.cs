using Cignium.pe.SearchFight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Printer
{
    public class PrinterStringBuilder : IPrinterBuilder
    {
        public string Print(SearchResult result)
        {
            StringBuilder builderResult = new StringBuilder();

            foreach (var eachInputResult in result.InputsSearchResults)
                builderResult.AppendLine($"{eachInputResult.KeyWord}: {BuildSearchEnginesResults(eachInputResult.ItemResults)}");

            foreach (var eachSearchEngineResults in result.SearchEngineResults)
                builderResult.AppendLine($"{eachSearchEngineResults.SearchEngineSite.Name} winner: {eachSearchEngineResults.InputWinner}");

            builderResult.AppendLine($"Total winner: {result.TotalWinner}");

            return builderResult.ToString();
        }

        private String BuildSearchEnginesResults(List<SearchEngineResult> itemResults)
        {
            StringBuilder builderResult = new StringBuilder();
            foreach (var each in itemResults)
                builderResult.Append($"\t{each.SearchEngineSite.Name}: {each.TotalResults}");
            return builderResult.ToString();
        }
    }
}
