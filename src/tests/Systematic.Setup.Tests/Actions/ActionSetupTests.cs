namespace Systematic.Setup.Tests.Actions
{
    using System;

    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class ActionSetupTests
    {
        [Test]
        public void Build_SetupComplete_ShouldReturn()
        {
            var scope = new DataScope();
            var setup = new ActionStubSetup
            {
                InputId = "inputData",
                OutputId = "outputData"
            };

            var actual = setup.Build(scope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.InputId, actual.InputId);
            Assert.AreEqual(setup.OutputId, actual.OutputId);
            Assert.AreSame(scope, actual.Scope);
        }

        [Test]
        public void Build_InputIdDefault_ShouldThrow()
        {
            var setup = new ActionStubSetup();

            Assert.Throws<InvalidOperationException>(() => setup.Build(new DataScope()));
        }
    }
}
