namespace Systematic.Setup.Tests.Actions
{
    using System;

    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Setup.Tests.Actions.Fixture;

    [TestFixture]
    internal class ActionSetupTests
    {
        [Test]
        public void Build_SetupComplete_ShouldReturn()
        {
            var setup = new ActionStubSetup
            {
                InputId = "inputData",
                OutputId = "outputData"
            };

            var actual = setup.Build(new DataScope());

            Assert.NotNull(actual);
            Assert.AreEqual(setup.InputId, actual.InputId);
            Assert.AreEqual(setup.OutputId, actual.OutputId);
        }

        [Test]
        public void Build_InputIdDefault_ShouldThrow()
        {
            var setup = new ActionStubSetup();

            Assert.Throws<InvalidOperationException>(() => setup.Build(new DataScope()));
        }
    }
}
