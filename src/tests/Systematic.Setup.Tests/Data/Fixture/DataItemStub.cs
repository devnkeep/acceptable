namespace Systematic.Setup.Tests.Data.Fixture
{
    using Systematic.Data;

    internal class DataItemStub : DataItem
    {
        public DataItemStub(int value) => Value = value;

        public int Value { get; set; }
    }
}
