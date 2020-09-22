using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TuneSearch.Common;

namespace TuneSearch.Infrastructure
{
    public class ITunesSearchAPI
    {
        const string Url = "https://itunes.apple.com/search";

        public async Task<Result<List<Result>>> GetSongs(string term)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                   (sender, certificate, chain, sslPolicyErrors) => {
                       if (sslPolicyErrors == SslPolicyErrors.None) return true;
                       return sender.RequestUri.Host == "itunes.apple.com";
                   };
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
                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var searchApiResults = SearchApiResults.FromJson(jsonString);
                return new Result<List<Result>>(searchApiResults.Results);
            }
            catch (Exception ex)
            {
                return new Result<List<Result>>(ex);
            }
            finally
            {                
                client.Dispose();
                handler.Dispose();
            }
        }
    }
}
