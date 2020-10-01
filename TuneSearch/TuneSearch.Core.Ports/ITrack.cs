namespace TuneSearch.Core.Ports
{
    public interface ITrack
    {
        string Title { get; }

        string Artist { get; }

        int? TrackNr { get; }
    }
}
