using System.Threading.Tasks;

namespace TuneSearch.Core.Ports
{
    public interface IInfrastructure
    {
        Task<ISearchResult> ProcessRequest(string searchTerm);
    }
}
