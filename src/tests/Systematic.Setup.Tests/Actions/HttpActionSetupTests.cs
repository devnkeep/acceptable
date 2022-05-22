namespace Systematic.Setup.Tests.Actions
{
    using System;

    using NUnit.Framework;

    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Tests.Fixture;

    [TestFixture]
    internal class HttpActionSetupTests
    {
        [Test]
        public void Build_SetupComplete_ShouldReturn()
        {
            var scope = new DataScope();
            var httpScope = new HttpScope();
            var setup = new HttpActionStubSetup
            {
                InputId = "inputData",
                OutputId = "outputData"
            };

            var actual = setup.Build(scope, httpScope);

            Assert.NotNull(actual);
            Assert.AreEqual(setup.InputId, actual.InputId);
            Assert.AreEqual(setup.OutputId, actual.OutputId);
            Assert.AreSame(scope, actual.Scope);
            Assert.AreSame(httpScope, actual.HttpScope);
        }

        [Test]
        public void Build_InputIdDefault_ShouldThrow()
        {
            var setup = new HttpActionStubSetup();

            Assert.Throws<InvalidOperationException>(() => setup.Build(new DataScope(), new HttpScope()));
        }
    }
}
