namespace Systematic.Setup.Tests.Data
{
    using System;

    using NUnit.Framework;

    using Systematic.Setup.Data;
    using Systematic.Setup.Tests.Data.Fixture;

    [TestFixture]
    internal class DataScopeSetupTests
    {
        [Test]
        public void Build_Empty_ShouldReturnEmpty()
        {
            var setup = new DataScopeSetup();

            var actual = setup.Build();

            Assert.NotNull(actual);
        }

        [Test]
        public void Build_WithDataSetup_ShouldReturnWithDataItem()
        {
            var setup = new DataScopeSetup();
            var dataSetup = DataItemStubSetup.Instance;
            setup.AddData(dataSetup);

            var actual = setup.Build();
            var dataItem = actual.Get<DataItemStub>(dataSetup.Id);

            Assert.NotNull(dataItem);
            Assert.AreEqual(dataSetup.Id, dataItem.Id);
            Assert.AreEqual(dataSetup.Value, dataItem.Value);
        }

        [Test]
        public void Build_CalledSecondTime_ShouldReturnSameInstance()
        {
            var setup = new DataScopeSetup();

            var firstActual = setup.Build();
            var secondActual = setup.Build();

            Assert.NotNull(firstActual);
            Assert.NotNull(secondActual);
            Assert.AreSame(firstActual, secondActual);
        }

        [Test]
        public void AddData_AfterBuild_ShouldThrow()
        {
            var setup = new DataScopeSetup();
            var dataSetup = DataItemStubSetup.Instance;

            setup.Build();

            Assert.Throws<InvalidOperationException>(() => setup.AddData(dataSetup));
        }

        [Test]
        public void RemoveData_AfterBuild_ShouldThrow()
        {
            var setup = new DataScopeSetup();
            var dataSetup = DataItemStubSetup.Instance;

            setup.Build();

            Assert.Throws<InvalidOperationException>(() => setup.RemoveData(dataSetup));
        }
    }
}
