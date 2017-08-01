using Cignium.pe.SearchFight.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.SearchTemplate
{
    public abstract class SearchEngineTemplateBase : ISearchEngine
    {
        public abstract ISearchEngineSite SearchEngineSite { get; }

        public Model.SearchEngineResult SearchAndGetTotalResults(String keywordSearch)
        {
            return new Model.SearchEngineResult
            {
                SearchEngineSite = this.SearchEngineSite,
                TotalResults = ExtractResult(RequestSearch(keywordSearch))
            };
        }

        public abstract Int64 ExtractResult(String responseString);
        public virtual string RequestSearch(String keywordSearch)
        {
            WebClient webClient = new WebClient();

            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("q", keywordSearch);

            webClient.QueryString.Add(nameValueCollection);
            return webClient.DownloadString(this.SearchEngineSite.UrlSearch);
        }
    }
}
