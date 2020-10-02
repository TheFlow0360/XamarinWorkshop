using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public string ArtworkUrl100 { get; set; }

        public string ArtworkUrl300 => Regex.Replace(ArtworkUrl100, @"^(.*)100x100(bb\.jpg)$",
            m => m.Groups[1].Value + "300x300" + m.Groups[2].Value);
    }
}
