using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Threading.Tasks;
using CommonPorts;

namespace TuneSearch.Infrastructure
{
    public class ITunesSearchAPI
    {
        const string Url = "https://itunes.apple.com/search";

        public async Task<Result<List<SearchApiResult>>> GetSongs(string term)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                   (sender, certificate, chain, sslPolicyErrors) => {
                       if (sslPolicyErrors == SslPolicyErrors.None) return true;
                       return sender.RequestUri.Host == "itunes.apple.com";
                   };
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://itunes.apple.com/search")
            };
            var media = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(media);            

            try
            {
                var builder = new UriBuilder(Url);
                var searchTerm = WebUtility.UrlEncode(term);
                builder.Query = $"entity=song&term={searchTerm}&country=de";
                var uri = builder.ToString();
                var searchApiResults = await client.GetFromJsonAsync<SearchApiResults>(uri);
                return new Result<List<SearchApiResult>>(searchApiResults.Results);
            }
            catch (Exception ex)
            {
                return new Result<List<SearchApiResult>>(ex);
            }
            finally
            {                
                client.Dispose();
                handler.Dispose();
            }
        }
    }
}
