using System;
using System.Threading.Tasks;
using TuneSearch.Core.Ports;

namespace TuneSearch.Core
{
    public class TuneSearchService : ISearchRequest
    {
        public Task<ISearchResult> ProcessRequest(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
