using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TuneSearch.Common;

namespace TuneSearch.Infrastructure
{
    public class ITunesSearchAPI
    {
        const string Url = "https://itunes.apple.com/search";

        public async Task<Result<List<TrackEntity>>> GetSongs(string term)
        {
            var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback +=
                   (sender, certificate, chain, sslPolicyErrors) => true;


            //            if (hostingEnvironment.IsDevelopment())
/*            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                   (sender, certificate, chain, sslPolicyErrors) => true;
            }*/

            var client = new HttpClient(handler);
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
                //var jsonObject = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());
                var tracks = JsonConvert.DeserializeObject<ResultEntity>(await httpResponse.Content.ReadAsStringAsync());
                return new Result<List<TrackEntity>>(tracks.results);
            }
            catch (Exception ex)
            {
                return new Result<List<TrackEntity>>(ex);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
