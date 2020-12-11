using System.Threading.Tasks;
using ExplicitArchitecture.TuneSearchExample.Core.Ports;
using NUnit.Framework;
using TuneSearch.Infrastructure.Adapters;

namespace TuneSearch.Core.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            var command = new SearchTracksService(new TunesSearchEngineAdapter());
            await command.Execute(new SearchTerm() { Term = "Jack+Johnson" }, success =>
            {
                Assert.AreEqual(5,success.Count);
            },error => {
            });
            Assert.Pass();
        }
    }

    internal class SearchTerm : ISearchTerm
    {
        public string Term { get; set; }
    }
}