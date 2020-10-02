using System.Collections.Generic;

namespace TuneSearch.Core.Ports
{
    public interface ISearchResult
    {
        IEnumerable<IAlbum> AlbumList { get; }
    }
}
