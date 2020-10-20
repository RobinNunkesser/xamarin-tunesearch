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
            await command.Execute(new SearchTracksDTO() { Term = "Jack+Johnson" }, success =>
            {
                Assert.AreEqual(5,success.Count);
            },error => {
            });
            Assert.Pass();
        }
    }
}