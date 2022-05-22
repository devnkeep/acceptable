namespace Systematic.Setup.Http.Actions
{
    using Systematic.Http.Actions;
    using Systematic.Http.Data;
    using Systematic.Text.Data;

    /// <summary>
    /// A setup of an action to send an HTTP request and return a response.
    /// </summary>
    public class SendRequestActionSetup : HttpActionSetup<RequestData, TextData>
    {
        /// <inheritdoc />
        public override string Name { get; } = "Send HTTP request";

        /// <inheritdoc />
        protected override HttpActionUnit<RequestData, TextData> BuildUnit() => new SendRequestAction();
    }
}
