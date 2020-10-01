using System;
using System.Collections.Generic;
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

    class SearchResultMock : ISearchResult
    {
        public IReadOnlyList<IAlbum> AlbumList => AlbumListInternal;

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

    class AlbumMock : IAlbum
    {
        public string Title { get; }

        public IReadOnlyList<ITrack> TrackList => TrackListInternal;

        public string AlbumArtSource => "https://community.mp3tag.de/uploads/default/original/2X/a/acf3edeb055e7b77114f9e393d1edeeda37e50c9.png";

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

    class TrackMock : ITrack
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public int? TrackNr { get; set; }
    }
}
