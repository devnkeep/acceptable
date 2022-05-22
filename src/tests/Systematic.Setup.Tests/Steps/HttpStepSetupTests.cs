namespace Systematic.Setup.Tests.Steps
{
    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Http.Steps;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class HttpStepSetupTests
    {
        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var scope = new DataScope();
            var setup = new HttpStepSetup { Name = nameof(HttpStepSetup) };

            var actual = setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.IsEmpty(actual.Actions);
        }

        [Test]
        public void Build_WithSimpleActions_ShouldReturnWithActions()
        {
            var scope = new DataScope();
            var setup = new HttpStepSetup { Name = nameof(HttpStepSetup) };
            var firstActionSetup = new ActionStubSetup { InputId = "inputData_0" };
            var secondActionSetup = new ActionStubSetup { InputId = "inputData_1" };
            setup.AddAction(firstActionSetup);
            setup.AddAction(secondActionSetup);

            var actual = setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreEqual(2, actual.Actions.Count);
        }

        [Test]
        public void Build_WithHttpActions_ShouldReturnWithActions()
        {
            var scope = new DataScope();
            var setup = new HttpStepSetup { Name = nameof(HttpStepSetup) };
            var firstActionSetup = new HttpActionStubSetup { InputId = "inputData_0" };
            var secondActionSetup = new HttpActionStubSetup { InputId = "inputData_1" };
            setup.AddAction(firstActionSetup);
            setup.AddAction(secondActionSetup);

            var actual = setup.Build(scope, new HttpScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.Name, actual.Name);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreEqual(2, actual.Actions.Count);
        }
    }
}
