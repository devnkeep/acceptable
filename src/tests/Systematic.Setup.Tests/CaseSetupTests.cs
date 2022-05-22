namespace Systematic.Setup.Tests
{
    using NUnit.Framework;

    using Systematic.Setup.Data;
    using Systematic.Setup.Http;
    using Systematic.Setup.Http.Sequences;
    using Systematic.Setup.Sequences;

    [TestFixture]
    internal class CaseSetupTests
    {
        private readonly IDataScopeSetupRegistry _scopes = new DataScopeSetupRegistry();

        private readonly IHttpScopeSetupRegistry _httpScopes = new HttpScopeSetupRegistry();

        private ScopeIdentifier _scopeId;

        private ScopeIdentifier _httpScopeId;

        [SetUp]
        public void SetUp()
        {
            _scopeId = _scopes.Create().Id;
            _httpScopeId = _httpScopes.Create().Id;
        }

        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var setup = new CaseSetup() { Name = nameof(CaseSetup) };

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.IsEmpty(actual.Sequences);
        }

        [Test]
        public void Build_WithSimpleSequence_ShouldReturnWithSequence()
        {
            var setup = new CaseSetup() { Name = nameof(CaseSetup) };
            setup.AddSequence(new SimpleSequenceSetup(_scopes) { Scope = _scopeId });

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreEqual(1, actual.Sequences.Count);
        }

        [Test]
        public void Build_WithHttpSequence_ShouldReturnWithSequence()
        {
            var setup = new CaseSetup() { Name = nameof(CaseSetup) };
            setup.AddSequence(new HttpSequenceSetup(_scopes, _httpScopes)
            {
                Scope = _scopeId,
                HttpScope = _httpScopeId
            });

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreEqual(1, actual.Sequences.Count);
        }
    }
}
