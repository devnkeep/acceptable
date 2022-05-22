namespace Systematic.Setup.Tests.Assertions
{
    using System;

    using NUnit.Framework;

    using Systematic.Assertions;
    using Systematic.Data.Scope;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class AssertionSetupTests
    {
        [Test]
        public void Build_PlainAssertion_SetupComplete_ShouldReturn()
        {
            var scope = new DataScope();
            var setup = new PlainAssertionStubSetup { InputId = "inputData" };

            var actual = setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.InputId, actual.InputId);
            Assert.AreSame(scope, actual.Scope);
        }

        [Test]
        public void Build_ExpectationAssertion_SetupComplete_ShouldReturn()
        {
            var scope = new DataScope();
            var setup = new ExpectationAssertionStubSetup
            {
                InputId = "inputData",
                ExpectationId = "expectationId"
            };

            var actual = (ExpectationAssertionContext<DataItemStub>)setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.InputId, actual.InputId);
            Assert.AreEqual(setup.ExpectationId, actual.ExpectationId);
            Assert.AreSame(scope, actual.Scope);
        }

        [Test]
        public void Build_PlainAssertion_InputIdDefault_ShouldThrow()
        {
            var setup = new PlainAssertionStubSetup();

            Assert.Throws<InvalidOperationException>(() => setup.Build(new DataScope()));
        }

        [Test]
        public void Build_ExpectationAssertion_InputIdDefault_ShouldThrow()
        {
            var setup = new ExpectationAssertionStubSetup();

            Assert.Throws<InvalidOperationException>(() => setup.Build(new DataScope()));
        }

        [Test]
        public void Build_ExpectationAssertion_ExpectationIdDefault_ShouldThrow()
        {
            var setup = new ExpectationAssertionStubSetup() { InputId = "inputData" };

            Assert.Throws<InvalidOperationException>(() => setup.Build(new DataScope()));
        }
    }
}
