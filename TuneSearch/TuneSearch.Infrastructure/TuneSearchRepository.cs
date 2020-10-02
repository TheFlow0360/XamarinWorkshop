using RestSharp;
using System;
using System.Threading.Tasks;
using TuneSearch.Core.Ports;

namespace TuneSearch.Infrastructure
{
    public class TuneSearchRepository : IInfrastructure
    {
        private static readonly string BaseUrl = "https://itunes.apple.com"; //search?term=

        public async Task<ISearchResult> ProcessRequest(string searchTerm)
        {
            try
            {
                var client = new RestClient(BaseUrl);
                var request = new RestRequest("search", DataFormat.Json);
                request.AddParameter("term", searchTerm, ParameterType.QueryString);
                
                var response = await client.ExecuteAsync<ITunesSearchResponse>(request);

                var result = new SearchResult();
                foreach (var searchResult in response.Data.Results)
                {
                    if (!result.AlbumListInternal.TryGetValue(searchResult.CollectionName, out var album)) 
                    {
                        album = new Album
                        {
                            Title = searchResult.CollectionName,
                            AlbumCoverSource = searchResult.ArtworkUrl30
                        };

                        result.AlbumListInternal.Add(searchResult.CollectionName, album);
                    }

                    album.TrackListInternal.Add(new Track()
                    {
                        Artist = searchResult.ArtistName,
                        Title = searchResult.TrackName,
                        TrackNr = searchResult.TrackNumber
                    });
                }

                return result;
            }
            catch(Exception)
            {
                // TODO error handling
                return new SearchResult();
            }
        }
    }
}
