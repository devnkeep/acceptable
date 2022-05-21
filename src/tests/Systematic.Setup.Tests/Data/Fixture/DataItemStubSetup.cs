namespace Systematic.Setup.Tests.Data.Fixture
{
    using Systematic.Setup.Data;

    internal class DataItemStubSetup : DataItemSetup<DataItemStub>
    {
        public static DataItemStubSetup Instance => new DataItemStubSetup { Id = "DataItemStubSetup", Value = 5 };

        public int Value { get; set; }

        protected override DataItemStub DoBuildItem() => new DataItemStub(Value);
    }
}
