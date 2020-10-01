using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using TuneSearch.Core.Ports;

namespace TuneSearch.Xamarin.UI
{
    class ResultsViewModel
    {
        public string Title { get; }

        public List<Album> SearchResults { get; }

        public ResultsViewModel(string title, ISearchResult result)
        {
            Title = title;
            SearchResults = new List<Album>();
            foreach (var album in result.AlbumList)
            {
                var albumEntry = new Album();
                albumEntry.Header.Title = album.Title;
                foreach (var track in album.TrackList)
                {
                    albumEntry.Add(new Track()
                    {
                        Title = track.Title,
                        Artist = track.Artist,
                        TrackNr = track.TrackNr,
                        AlbumCoverSource = album.AlbumCoverSource
                    });

                    albumEntry.Header.Artists.Add(track.Artist);
                }

                SearchResults.Add(albumEntry);
            }
        }

        public class Album : List<Track>
        {
            public AlbumHeader Header { get; } = new AlbumHeader();

            public String ShortName => Header.Title.Length > 0 ? Header.Title.Substring(0, 1) : "";
        }

        public class Track
        {
            public string Title { get; set; }

            public string Artist { get; set; }

            public int? TrackNr { get; set; }

            public string AlbumCoverSource { get; set; }
        }

        public class AlbumHeader
        {
            public string Title { get; set; }

            public HashSet<string> Artists { get; } = new HashSet<string>();

            public string ArtistDisplay => $"({string.Join(", ", Artists)})";
        }
    }
}
