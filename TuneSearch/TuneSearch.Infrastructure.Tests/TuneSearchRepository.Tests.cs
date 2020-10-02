using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace TuneSearch.Infrastructure.Tests
{
    public class TuneSearchRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ApiCallWorking()
        {
            var repo = new TuneSearchRepository();

            var result = await repo.ProcessRequest("Linkin Park");

            Assert.NotNull(result);
            Assert.IsTrue(result.AlbumList.Any());
        }
    }
}