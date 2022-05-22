namespace Systematic.Setup.Tests.AssertionSteps
{
    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Setup.AssertionSteps;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class SimpleAssertionStepSetupTests
    {
        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var scope = new DataScope();
            var setup = new SimpleAssertionStepSetup { Name = nameof(SimpleAssertionStepSetup) };

            var actual = (AssertionStep)setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.IsEmpty(actual.Actions);
            Assert.IsEmpty(actual.Assertions);
        }

        [Test]
        public void Build_WithActions_ShouldReturnWithActions()
        {
            var scope = new DataScope();
            var setup = new SimpleAssertionStepSetup { Name = nameof(SimpleAssertionStepSetup) };
            var firstActionSetup = new ActionStubSetup { InputId = "inputData_0" };
            var secondActionSetup = new ActionStubSetup { InputId = "inputData_1" };
            setup.AddAction(firstActionSetup);
            setup.AddAction(secondActionSetup);

            var actual = (AssertionStep)setup.Build(scope);

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
            var setup = new SimpleAssertionStepSetup { Name = nameof(SimpleAssertionStepSetup) };
            var firstAssertionSetup = new PlainAssertionStubSetup { InputId = "inputData_0" };
            var secondAssertionSetup = new PlainAssertionStubSetup { InputId = "inputData_1" };
            setup.AddAssertion(firstAssertionSetup);
            setup.AddAssertion(secondAssertionSetup);

            var actual = (AssertionStep)setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.IsEmpty(actual.Actions);
            Assert.AreEqual(2, actual.Assertions.Count);
        }

        [Test]
        public void Build_ActionAndAssertion_ShouldReturnWithActionAndAssertion()
        {
            var scope = new DataScope();
            var setup = new SimpleAssertionStepSetup { Name = nameof(SimpleAssertionStepSetup) };
            var actionSetup = new ActionStubSetup { InputId = "inputData_0" };
            var assertionSetup = new PlainAssertionStubSetup { InputId = "inputData_1" };
            setup.AddAction(actionSetup);
            setup.AddAssertion(assertionSetup);

            var actual = (AssertionStep)setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreEqual(1, actual.Actions.Count);
            Assert.AreEqual(1, actual.Assertions.Count);
        }
    }
}
