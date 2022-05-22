namespace Systematic.IntegrationTests
{
    using System.Threading;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Fixture = JsonStringNotEmptyCaseFixture;

    [TestFixture]
    internal class JsonStringNotEmptyCaseTests
    {
        [Test]
        public async Task TestAsync_ShouldSucceed()
        {
            var (testCase, httpScope) = Fixture.BuildCase();

            using (httpScope)
            {
                var result = await testCase.TestAsync(CancellationToken.None);

                Assert.True(result.Success);
            }
        }
    }
}
