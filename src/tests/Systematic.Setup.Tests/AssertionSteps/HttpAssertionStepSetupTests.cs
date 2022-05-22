namespace Systematic.Setup.Tests.AssertionSteps
{
    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Http.AssertionSteps;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class HttpAssertionStepSetupTests
    {
        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var scope = new DataScope();
            var setup = new HttpAssertionStepSetup { Name = nameof(HttpAssertionStepSetup) };

            var actual = (AssertionStep)setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.IsEmpty(actual.Actions);
            Assert.IsEmpty(actual.Assertions);
        }

        [Test]
        public void Build_WithSimpleActions_ShouldReturnWithActions()
        {
            var scope = new DataScope();
            var setup = new HttpAssertionStepSetup { Name = nameof(HttpAssertionStepSetup) };
            var firstActionSetup = new ActionStubSetup { InputId = "inputData_0" };
            var secondActionSetup = new ActionStubSetup { InputId = "inputData_1" };
            setup.AddAction(firstActionSetup);
            setup.AddAction(secondActionSetup);

            var actual = (AssertionStep)setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreEqual(2, actual.Actions.Count);
            Assert.IsEmpty(actual.Assertions);
        }

        [Test]
        public void Build_WithAssertions_ShouldReturnWithAssertions()
        {
            var scope = new DataScope();
            var setup = new HttpAssertionStepSetup { Name = nameof(HttpAssertionStepSetup) };
            var firstAssertionSetup = new PlainAssertionStubSetup { InputId = "inputData_0" };
            var secondAssertionSetup = new PlainAssertionStubSetup { InputId = "inputData_1" };
            setup.AddAssertion(firstAssertionSetup);
            setup.AddAssertion(secondAssertionSetup);

            var actual = (AssertionStep)setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.IsEmpty(actual.Actions);
            Assert.AreEqual(2, actual.Assertions.Count);
        }

        [Test]
        public void Build_HttpActionAndAssertion_ShouldReturnWithActionAndAssertion()
        {
            var scope = new DataScope();
            var setup = new HttpAssertionStepSetup { Name = nameof(HttpAssertionStepSetup) };
            var actionSetup = new HttpActionStubSetup { InputId = "inputData_0" };
            var assertionSetup = new PlainAssertionStubSetup { InputId = "inputData_1" };
            setup.AddAction(actionSetup);
            setup.AddAssertion(assertionSetup);

            var actual = (AssertionStep)setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreEqual(1, actual.Actions.Count);
            Assert.AreEqual(1, actual.Assertions.Count);
        }
    }
}
