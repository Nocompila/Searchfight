using Cignium.pe.SearchFight.Engine;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.pe.SearchFight.Consola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new SearchEngineExecutor().ExecuteSearch(args));
            Console.ReadLine();
        }
    }
}
