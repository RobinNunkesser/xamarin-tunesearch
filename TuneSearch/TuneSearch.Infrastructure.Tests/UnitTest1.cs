using System.Threading.Tasks;
using NUnit.Framework;

namespace TuneSearch.Infrastructure.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var api = new ITunesSearchAPI();
            var response = await api.GetSongs("Jack+Johnson");

            response.Match(success => {
                Assert.AreEqual(50, success.Count);
            },
                failure => throw failure);            
        }
    }
}