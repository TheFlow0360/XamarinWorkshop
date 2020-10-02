using System;
using System.Collections.Generic;
using System.Linq;
using TuneSearch.Core.Ports;

namespace TuneSearch.Infrastructure
{
    public class SearchResult : ISearchResult
    {
        public IEnumerable<IAlbum> AlbumList => AlbumListInternal.Values;

        public Dictionary<string, Album> AlbumListInternal { get; } = new Dictionary<string, Album>();
    }
}
