using TuneSearch.Core.Ports;

namespace TuneSearch.Infrastructure
{
    public class Track : ITrack
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public int? TrackNr { get; set; }

        public int TrackNrNotNull => TrackNr.HasValue ? TrackNr.Value : int.MinValue;
    }
}
