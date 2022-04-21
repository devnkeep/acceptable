namespace Acceptable.IntegrationTests
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Fixture = FileTextEqualityCaseFixture;

    [TestFixture]
    internal class FileTextEqualityCaseTests
    {
        private static readonly string TestDirectoryPath = Path.Combine(Path.GetTempPath(), "Acceptable.IntegrationTests", "ReadFileCaseTests");

        private static readonly string EmptyFilePath = Path.Combine(TestDirectoryPath, "empty.txt");

        private static readonly string WithTextFilePath = Path.Combine(TestDirectoryPath, "with-text.txt");

        private static readonly string NonExistantFilePath = Path.Combine(TestDirectoryPath, "not-found.txt");

        [OneTimeSetUp]
        public void SetUp()
        {
            if (!Directory.Exists(TestDirectoryPath))
                Directory.CreateDirectory(TestDirectoryPath);

            if (File.Exists(EmptyFilePath))
                File.Delete(EmptyFilePath);

            using var emptyFs = File.CreateText(EmptyFilePath);

            if (File.Exists(WithTextFilePath))
                File.Delete(WithTextFilePath);

            using var withTextFs = File.CreateText(WithTextFilePath);
            withTextFs.Write(Fixture.TestText);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(TestDirectoryPath))
                Directory.Delete(TestDirectoryPath, true);
        }

        [Test]
        public async Task TestAsync_FileWithText_ShouldSucceed()
        {
            var testCase = Fixture.BuildCase(WithTextFilePath);

            var result = await testCase.TestAsync(CancellationToken.None);

            Assert.True(result.Success);
        }

        [Test]
        public async Task TestAsync_EmptyFile_ShouldFail()
        {
            var testCase = Fixture.BuildCase(EmptyFilePath);

            var result = await testCase.TestAsync(CancellationToken.None);

            Assert.False(result.Success);
        }

        [Test]
        public void TestAsync_FileDoesntExist_ShouldFail()
        {
            var testCase = Fixture.BuildCase(NonExistantFilePath);

            Assert.ThrowsAsync<FileNotFoundException>(() => testCase.TestAsync(CancellationToken.None));
        }
    }
}
