using Cignium.pe.SearchFight.SearchTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cignium.pe.SearchFight.Model;

namespace Cignium.pe.SearchFight.MSNSearch
{
    public class MSNSearchEngine : SearchEngineTemplateBase
    {
        private const string TokenForGetResult = "class=\"sb_count\"";

        public override ISearchEngineSite SearchEngineSite => new SearchEngineSite
        {
            UrlSearch = "https://www.bing.com/search",
            Name = "MSN"
        };

        public override long ExtractResult(string responseString)
        {
            if (!responseString.Contains(TokenForGetResult)) throw new InvalidOperationException("The total results is not valid");

            string afterTokenResult = responseString.Substring(responseString.IndexOf(TokenForGetResult) + TokenForGetResult.Length);
            string beforeCloseTagResult = afterTokenResult.Substring(afterTokenResult.IndexOf(">"));
            string bruteResult = afterTokenResult.Substring(0, beforeCloseTagResult.IndexOf("<"));
            return Convert.ToInt64(BruteResultHelper.GetDigits(bruteResult));
        }

        public override string RequestSearch(string keywordSearch)
        {
            base.RequestSearch(keywordSearch);
            return base.RequestSearch(keywordSearch);
        }

    }
}
