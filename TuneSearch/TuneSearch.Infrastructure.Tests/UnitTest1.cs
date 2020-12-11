using System.Threading.Tasks;
using NUnit.Framework;
using TuneSearch.Infrastructure.Adapters;

namespace TuneSearch.Infrastructure.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAPI()
        {
            var api = new ITunesSearchAPI();
            var response = await api.GetSongs("Jack+Johnson");

            response.Match(success => {
                Assert.AreEqual(50, success.Count);
            },
                failure => throw failure);            
        }

        [Test]
        public async Task TestAdapter()
        {
            var adapter = new TunesSearchEngineAdapter();
            var response = await adapter.GetSongs("Jack+Johnson");

            response.Match(success => {
                Assert.AreEqual(50, success.Count);
            },
                failure => throw failure);
        }

    }
}