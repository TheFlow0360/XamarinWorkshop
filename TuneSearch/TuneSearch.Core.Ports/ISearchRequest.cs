using System.Threading.Tasks;

namespace TuneSearch.Core.Ports
{
    public interface ISearchRequest
    {
        Task<ISearchResult> ProcessRequest(string searchTerm);
    }
}
