using System;
using System.Collections.Generic;

namespace TuneSearch.Infrastructure
{
    public class ITunesSearchResponse
    {
        public long ResultCount { get; set; }

        public List<ITunesResult> Results { get; set; }
    }

    public class ITunesResult
    {
        public string ArtistName { get; set; }

        public string CollectionName { get; set; }

        public string TrackName { get; set; }

        public int TrackNumber { get; set; }

        public string ArtworkUrl30 { get; set; }
    }
}
