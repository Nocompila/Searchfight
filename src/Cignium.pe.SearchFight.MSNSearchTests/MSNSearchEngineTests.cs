using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cignium.pe.SearchFight.MSNSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.MSNSearch.Tests
{
    [TestClass()]
    public class MSNSearchEngineTests
    {
        [TestMethod()]
        public void ExtractResult_WithValidToken_ShouldReturnValidResult()
        {
            long expected = 1211;
            long result = new MSNSearchEngine().ExtractResult("<class=\"sb_count\">1211<");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExtractResult_WithNoToken_ExceptionShouldBeThrow()
        {
            new MSNSearchEngine().ExtractResult(">1211<");
        }


    }
}