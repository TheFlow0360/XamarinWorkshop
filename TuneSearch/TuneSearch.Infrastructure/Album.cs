using System;
using System.Collections.Generic;
using TuneSearch.Core.Ports;

namespace TuneSearch.Infrastructure
{
    public class Album : IAlbum
    {
        public string Title { get; set; }

        public IEnumerable<ITrack> TrackList => TrackListInternal;

        public List<ITrack> TrackListInternal { get; } = new List<ITrack>();

        public string AlbumCoverSource { get; set; }
    }
}
