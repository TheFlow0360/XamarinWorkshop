using TuneSearch.Core.Ports;

namespace TuneSearch.Xamarin.UI.Mocks
{
    class TrackMock : ITrack
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public int? TrackNr { get; set; }
    }
}
