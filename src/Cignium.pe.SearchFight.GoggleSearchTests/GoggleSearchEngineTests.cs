using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cignium.pe.SearchFight.GoggleSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.GoggleSearch.Tests
{
    [TestClass()]
    public class GoggleSearchEngineTests
    {
        [TestMethod()]
        public void ExtractResult_WithValidToken_ShouldReturnValidResult()
        {
            long expected = 1211;
            long result = new GoggleSearchEngine().ExtractResult("<class=\"resultStats\">1211<");
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExtractResult_WithNoToken_ExceptionShouldBeThrow()
        {
            new GoggleSearchEngine().ExtractResult(">1211<");
        }
    }
}