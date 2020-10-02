using System.Collections.Generic;
using TuneSearch.Core.Ports;

namespace TuneSearch.Xamarin.UI.Mocks
{
    class SearchResultMock : ISearchResult
    {
        public IEnumerable<IAlbum> AlbumList => AlbumListInternal;

        private List<IAlbum> AlbumListInternal { get; }

        public SearchResultMock()
        {
            AlbumListInternal = new List<IAlbum>()
            {
                new AlbumMock("Foobar"),
                new AlbumMock("1337"),
                new AlbumMock("Xamarin Workshop Rock(s)")
            };
        }
    }
}
