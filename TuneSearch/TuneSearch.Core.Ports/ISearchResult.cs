using System.Collections.Generic;

namespace TuneSearch.Core.Ports
{
    public interface ISearchResult
    {
        IReadOnlyList<IAlbum> AlbumList { get; }
    }
}
