using System;
using System.Collections.Generic;
using System.Dynamic;
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
                albumEntry.Title = album.Title;
                foreach (var track in album.TrackList)
                {
                    albumEntry.Add(new Track()
                    {
                        Title = track.Title,
                        Artist = track.Artist,
                        TrackNr = track.TrackNr,
                        AlbumCoverSource = album.AlbumCoverSource
                    });
                }

                SearchResults.Add(albumEntry);
            }
        }

        public class Album : List<Track>
        {
            public string Title { get; set; }
        }

        public class Track
        {
            public string Title { get; set; }

            public string Artist { get; set; }

            public int? TrackNr { get; set; }

            public string AlbumCoverSource { get; set; }
        }
    }
}
