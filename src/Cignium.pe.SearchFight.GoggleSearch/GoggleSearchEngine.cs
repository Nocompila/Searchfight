using Cignium.pe.SearchFight.SearchTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cignium.pe.SearchFight.Model;

namespace Cignium.pe.SearchFight.GoggleSearch
{
    public class GoggleSearchEngine : SearchEngineTemplateBase
    {
        private const string TokenForGetResult = "\"resultStats\">";

        public override ISearchEngineSite SearchEngineSite => new SearchEngineSite
        {
            Name = "Google",
            UrlSearch = "http://www.google.com.pe/search"
        };

        public override Int64 ExtractResult(string responseString)
        {
            String afterTokenResult = responseString.Substring(responseString.IndexOf(TokenForGetResult) + TokenForGetResult.Length);
            String bruteResult = afterTokenResult.Substring(0, afterTokenResult.IndexOf("<"));
            return Convert.ToInt64(BruteResultHelper.GetDigits(bruteResult));
        }
       
    }
}
