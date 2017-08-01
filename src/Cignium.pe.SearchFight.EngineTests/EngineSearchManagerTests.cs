using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cignium.pe.SearchFight.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cignium.pe.SearchFight.GoggleSearch;
using Cignium.pe.SearchFight.MSNSearch;

namespace Cignium.pe.SearchFight.Engine.Tests
{
    [TestClass()]
    public class EngineSearchManagerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeEngineSearch_WithNoEngines_ExceptionShouldBeThrow()
        {
            new EngineSearchManager(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeEngineSearch_With1Engine_ExceptionShouldBeThrow()
        {
            new EngineSearchManager(new List<Model.ISearchEngine> { new GoggleSearchEngine() });
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchTest_With1KeyWord_ExceptionShouldBeThrow()
        {
            ValidEngineSearchManager().Search(new String[] { ".net" });
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchTest_WithNoKeyWord_ExceptionShouldBeThrow()
        {
            ValidEngineSearchManager().Search(new String[] { });
        }

        private static EngineSearchManager ValidEngineSearchManager()
        {
            return new EngineSearchManager(new List<Model.ISearchEngine> { new GoggleSearchEngine(), new MSNSearchEngine() });
        }
    }
}