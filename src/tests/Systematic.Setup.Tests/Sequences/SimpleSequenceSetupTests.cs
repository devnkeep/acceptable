namespace Systematic.Setup.Tests.Sequences
{
    using System;

    using NUnit.Framework;

    using Systematic.Setup.Data;
    using Systematic.Setup.Sequences;
    using Systematic.Setup.Steps;

    [TestFixture]
    internal class SimpleSequenceSetupTests
    {
        private readonly IDataScopeSetupRegistry _scopes = new DataScopeSetupRegistry();

        private ScopeIdentifier _scopeId;

        [SetUp]
        public void SetUp() => _scopeId = _scopes.Create().Id;

        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var setup = new SimpleSequenceSetup(_scopes)
            {
                Name = nameof(SimpleSequenceSetup),
                Scope = _scopeId
            };

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.IsEmpty(actual.Steps);
        }

        [Test]
        public void Build_WithStep_ShouldReturnWithStep()
        {
            var setup = new SimpleSequenceSetup(_scopes)
            {
                Name = nameof(SimpleSequenceSetup),
                Scope = _scopeId
            };
            setup.AddStep(new SimpleStepSetup());

            var actual = setup.Build();

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreEqual(1, actual.Steps.Count);
        }

        [Test]
        public void Build_ScopeDefault_ShouldThrow()
        {
            var setup = new SimpleSequenceSetup(_scopes) { Name = nameof(SimpleSequenceSetup) };
            setup.AddStep(new SimpleStepSetup());

            Assert.Throws<InvalidOperationException>(() => setup.Build());
        }
    }
}
