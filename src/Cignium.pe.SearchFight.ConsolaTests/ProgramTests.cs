using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cignium.pe.SearchFight.Consola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Consola.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            Program.Main(new string[] { ".net", "java" });
        }
    }
}