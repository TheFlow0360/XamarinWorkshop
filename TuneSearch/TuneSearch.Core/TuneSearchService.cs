using System;
using System.Threading.Tasks;
using TuneSearch.Core.Ports;

namespace TuneSearch.Core
{
    public class TuneSearchService : ISearchRequest
    {
        private IInfrastructure Infrastructure { get; }

        public TuneSearchService(IInfrastructure infrastructure)
        {
            Infrastructure = infrastructure;
        }

        public async Task<ISearchResult> ProcessRequest(string searchTerm)
        {
            return await Infrastructure.ProcessRequest(searchTerm);
        }
    }
}
