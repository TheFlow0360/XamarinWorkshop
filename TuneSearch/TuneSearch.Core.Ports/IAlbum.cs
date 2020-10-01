using System.Collections.Generic;

namespace TuneSearch.Core.Ports
{
    public interface IAlbum
    {
        string Title { get; }

        IReadOnlyList<ITrack> TrackList { get; }

        string AlbumCoverSource { get; }
    }
}
