namespace Systematic.Setup.Tests.Sequences
{
    using System;

    using NUnit.Framework;

    using Systematic.Setup.Data;
    using Systematic.Setup.Http;
    using Systematic.Setup.Http.Sequences;
    using Systematic.Setup.Http.Steps;
    using Systematic.Setup.Steps;

    [TestFixture]
    internal class HttpSequenceSetupTests
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
            var setup = new HttpSequenceSetup(_scopes, _httpScopes)
            {
                Name = nameof(HttpSequenceSetup),
                Scope = _scopeId,
                HttpScope = _httpScopeId
            };

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.IsEmpty(actual.Steps);
        }

        [Test]
        public void Build_WithSimpleStep_ShouldReturnWithStep()
        {
            var setup = new HttpSequenceSetup(_scopes, _httpScopes)
            {
                Name = nameof(HttpSequenceSetup),
                Scope = _scopeId,
                HttpScope = _httpScopeId
            };
            setup.AddStep(new SimpleStepSetup());

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreEqual(1, actual.Steps.Count);
        }

        [Test]
        public void Build_WithHttpStep_ShouldReturnWithStep()
        {
            var setup = new HttpSequenceSetup(_scopes, _httpScopes)
            {
                Name = nameof(HttpSequenceSetup),
                Scope = _scopeId,
                HttpScope = _httpScopeId
            };
            setup.AddStep(new HttpStepSetup());

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreEqual(1, actual.Steps.Count);
        }

        [Test]
        public void Build_ScopeDefault_ShouldThrow()
        {
            var setup = new HttpSequenceSetup(_scopes, _httpScopes) { Name = nameof(HttpSequenceSetup) };
            setup.AddStep(new HttpStepSetup());

            Assert.Throws<InvalidOperationException>(() => setup.Build());
        }

        [Test]
        public void Build_HttpScopeDefault_ShouldThrow()
        {
            var setup = new HttpSequenceSetup(_scopes, _httpScopes)
            {
                Name = nameof(HttpSequenceSetup),
                Scope = _scopeId
            };
            setup.AddStep(new HttpStepSetup());

            Assert.Throws<InvalidOperationException>(() => setup.Build());
        }
    }
}
