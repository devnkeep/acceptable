namespace Systematic.Setup.Tests.Steps
{
    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Setup.Steps;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class SimpleStepSetupTests
    {
        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var scope = new DataScope();
            var setup = new SimpleStepSetup { Name = nameof(SimpleStepSetup) };

            var actual = setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.IsEmpty(actual.Actions);
        }

        [Test]
        public void Build_WithActions_ShouldReturnWithActions()
        {
            var scope = new DataScope();
            var setup = new SimpleStepSetup { Name = nameof(SimpleStepSetup) };
            var firstActionSetup = new ActionStubSetup { InputId = "inputData_0" };
            var secondActionSetup = new ActionStubSetup { InputId = "inputData_1" };
            setup.AddAction(firstActionSetup);
            setup.AddAction(secondActionSetup);

            var actual = setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreEqual(2, actual.Actions.Count);
        }
    }
}
