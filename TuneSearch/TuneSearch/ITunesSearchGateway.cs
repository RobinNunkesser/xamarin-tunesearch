using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TuneSearch.Common;

namespace TuneSearch
{
    public class ITunesSearchGateway
    {
        const string Url = "https://itunes.apple.com/search";

        public async Task<Response<IEnumerable<TrackEntity>>> GetSongs(string term)
        {
            var client = new HttpClient();
            var media = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(media);

            try
            {
                var builder = new UriBuilder(Url);
                var searchTerm = WebUtility.UrlEncode(term);
                builder.Query = $"entity=song&term={searchTerm}&country=de";
                var uri = builder.ToString();
                var httpResponse = await client.GetAsync(uri);
                httpResponse.EnsureSuccessStatusCode();
                var jsonObject = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());
                var tracks = JsonConvert.DeserializeObject<ResultEntity>(jsonObject.ToString());
                return new Response< IEnumerable < TrackEntity >> (tracks.results);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<TrackEntity>>(ex);
            } 
            finally {
                client.Dispose();
            }
        }  

    }
}
