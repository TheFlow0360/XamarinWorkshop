using System.Collections.Generic;
using TuneSearch.Core.Ports;

namespace TuneSearch.Xamarin.UI.Mocks
{
    class AlbumMock : IAlbum
    {
        public string Title { get; }

        public IReadOnlyList<ITrack> TrackList => TrackListInternal;

        public string AlbumCoverSource => "https://community.mp3tag.de/uploads/default/original/2X/a/acf3edeb055e7b77114f9e393d1edeeda37e50c9.png";

        private List<ITrack> TrackListInternal { get; }

        public AlbumMock(string title)
        {
            Title = title;
            var c = 0;
            TrackListInternal = new List<ITrack>()
            {
                new TrackMock() { Title = "First Track", Artist = $"{Title} Artist", TrackNr = ++c },
                new TrackMock() { Title = "Second Track", Artist = $"{Title} Artist", TrackNr = ++c },
                new TrackMock() { Title = "Third Track", Artist = $"{Title} Artist", TrackNr = ++c },
                new TrackMock() { Title = "Last Track", Artist = $"{Title} Artist", TrackNr = ++c },
            };
        }
    }
}
