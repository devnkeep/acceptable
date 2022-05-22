namespace Systematic.IntegrationTests
{
    using System;
    using System.Net.Http;

    using Systematic.Assertions;
    using Systematic.Data.Scope;
    using Systematic.Http.Actions;
    using Systematic.Http.Data;
    using Systematic.Http.Scope;
    using Systematic.Text.Assertions;
    using Systematic.Text.Data;

    internal static class JsonStringNotEmptyCaseFixture
    {
        public static (Case, IHttpScope) BuildCase()
        {
            var scope = CreateScope();
            var httpScope = CreateHttpScope();
            var testCase = CreateCase(scope, httpScope);
            return (testCase, httpScope);
        }

        private static IDataScope CreateScope()
        {
            var scope = new DataScope();

            var uri = new Uri("https://jsonplaceholder.typicode.com/posts/1");
            var httpMethod = HttpMethod.Get;

            var request = new RequestData(uri, httpMethod);
            request.Identify("request");
            scope.Set(request);

            return scope;
        }

        private static IHttpScope CreateHttpScope() => new HttpScope();

        private static Case CreateCase(IDataScope scope, IHttpScope httpScope)
        {
            var testCase = new Case("Response JSON should not be empty");

            var sequence = CreateSequence(scope, httpScope);
            testCase.AddSequence(sequence);

            return testCase;
        }

        private static Sequence CreateSequence(IDataScope scope, IHttpScope httpScope)
        {
            var sequence = new Sequence("Check response JSON should not be empty");

            var step = CreateSendRequestStep(scope, httpScope);
            sequence.AddStep(step);

            var assertionStep = CreateTextEqualsAssertionStep(scope);
            sequence.AddStep(assertionStep);

            return sequence;
        }

        private static Step CreateSendRequestStep(IDataScope scope, IHttpScope httpScope)
        {
            var step = new Step("Send request and get JSON");
            step.SpecifyScope(scope);

            var sendRequestAction = CreateSendRequestAction(scope, httpScope);
            step.AddAction(sendRequestAction);

            return step;
        }

        private static HttpActionContext CreateSendRequestAction(IDataScope scope, IHttpScope httpScope)
        {
            var action = new HttpActionContext<RequestData, TextData>(new SendRequestAction());
            action.SpecifyScope(scope);
            action.SpecifyScope(httpScope);
            action.IdentifyInput("request");
            action.IdentifyOutput("json");

            return action;
        }

        private static AssertionStep CreateTextEqualsAssertionStep(IDataScope scope)
        {
            var assertionStep = new AssertionStep("Assert text not empty");
            assertionStep.SpecifyScope(scope);

            var notEmptyAssertion = CreateTextNotEmptyAssertion(scope);
            assertionStep.AddAssertion(notEmptyAssertion);

            return assertionStep;
        }

        private static AssertionContext CreateTextNotEmptyAssertion(IDataScope scope)
        {
            var assertion = new AssertionContext<TextData>(new TextNotEmptyAssertion());
            assertion.SpecifyScope(scope);
            assertion.IdentifyInput("json");

            return assertion;
        }
    }
}
