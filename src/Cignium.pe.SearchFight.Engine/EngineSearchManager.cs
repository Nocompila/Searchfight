using Cignium.pe.SearchFight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Engine
{
    public class EngineSearchManager
    {
        List<Model.ISearchEngine> SearchEngines { get; set; } = new List<ISearchEngine>();

        public EngineSearchManager(List<Model.ISearchEngine> searchEngines)
        {
            if (searchEngines == null || searchEngines.Count < 2) throw new ArgumentException("Should provide at least 2 search engines.");
            this.SearchEngines.AddRange(searchEngines);
        }

        public SearchResult Search(string[] keywords)
        {
            if (keywords == null || keywords.Count() < 2) throw new ArgumentException("Should provide at least 2 keywords in order to compare them.");
            if (keywords.Any(t => String.IsNullOrEmpty(t))) throw new ArgumentException("Keyword can not be empty");

            SearchResult result = new SearchResult();
            foreach (string eachKeyWord in keywords)
                result.InputsSearchResults.Add(new InputSearchResult
                {
                    KeyWord = eachKeyWord,
                    ItemResults = GetSearchRestuls(eachKeyWord)
                });

            result.SearchEngineResults = CalculateSearchEngineWinners(result);
            result.TotalWinner = CalculateTotalWinner(result, keywords);
            return result;
        }
        public String CalculateTotalWinner(SearchResult result, string[] keyWords)
        {
            List<RateSearchEngine> rates = new List<RateSearchEngine>();
            foreach (string eachKeyWord in keyWords)
                rates.Add(new RateSearchEngine
                {
                    KeyWord = eachKeyWord,
                    Total = result
                            .InputsSearchResults
                            .Single(t => t.KeyWord == eachKeyWord)
                            .ItemResults
                            .Sum(t => t.TotalResults)
                });

            return rates.OrderByDescending(t => t.Total).First().KeyWord;
        }

        public List<SearchEngineResult> CalculateSearchEngineWinners(SearchResult result)
        {
            List<SearchEngineResult> searchEngineResult = new List<SearchEngineResult>();
            foreach (var eachEngine in this.SearchEngines)
                CalculaEachEngine(result, searchEngineResult, eachEngine);
            return searchEngineResult;
        }

        private static void CalculaEachEngine(SearchResult result, List<SearchEngineResult> searchEngineResult, ISearchEngine eachEngine)
        {
            List<RateSearchEngine> rates = new List<RateSearchEngine>();

            foreach (var eachInputResult in result.InputsSearchResults)
            {
                rates.Add(new RateSearchEngine
                {
                    SearchEngineName = eachEngine.SearchEngineSite.Name,
                    KeyWord = eachInputResult.KeyWord,
                    Total = eachInputResult.ItemResults.Single(t => t.SearchEngineSite.Name == eachEngine.SearchEngineSite.Name).TotalResults
                });
            }

            searchEngineResult.Add(new SearchEngineResult
            {
                SearchEngineSite = eachEngine.SearchEngineSite,
                InputWinner = rates.OrderByDescending(t => t.Total).First().KeyWord
            });
        }

        private List<SearchEngineResult> GetSearchRestuls(string eachKeyWord)
        {
            List<SearchEngineResult> results = new List<SearchEngineResult>();
            foreach (var eachSearchEngine in this.SearchEngines)
                results.Add(eachSearchEngine.SearchAndGetTotalResults(eachKeyWord));
            return results;
        }
    }
}
