using System;
using System.Text;
using System.Threading.Tasks;
using TuneSearch.Core.Ports;

namespace TuneSearch.Xamarin.UI.Mocks
{
    class SearchRequestMock : ISearchRequest
    {
        public async Task<ISearchResult> ProcessRequest(string searchTerm)
        {
            return await Task.Delay(2000).ContinueWith(task => new SearchResultMock());
        }
    }
}
