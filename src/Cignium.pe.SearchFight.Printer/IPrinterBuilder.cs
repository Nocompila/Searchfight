using Cignium.pe.SearchFight.Model;

namespace Cignium.pe.SearchFight.Printer
{
    public interface IPrinterBuilder
    {
        string Print(SearchResult result);
    }
}