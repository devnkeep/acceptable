namespace Systematic.IntegrationTests
{
    using Systematic.Actions;
    using Systematic.Assertions;
    using Systematic.Data.Scope;
    using Systematic.FileSystem.Actions;
    using Systematic.FileSystem.Data;
    using Systematic.Text.Assertions;
    using Systematic.Text.Data;

    internal static class FileTextEqualityCaseFixture
    {
        public const string TestText = "Test Text";

        public static Case BuildCase(string filePath)
        {
            var scope = CreateScope(filePath);
            return CreateCase(scope);
        }

        private static IDataScope CreateScope(string filePath)
        {
            var scope = new DataScope();

            var initialPath = new PathData(filePath);
            initialPath.Identify("path");
            scope.Set(initialPath);

            var expectedText = new TextData(TestText);
            expectedText.Identify("expectedText");
            scope.Set(expectedText);

            return scope;
        }

        private static Case CreateCase(IDataScope scope)
        {
            var testCase = new Case("File content should be equal to 'TestText'");

            var sequence = CreateSequence(scope);
            testCase.AddSequence(sequence);

            return testCase;
        }

        private static Sequence CreateSequence(IDataScope scope)
        {
            var sequence = new Sequence("Check file text equals TestText");

            var step = CreateGetFileTextStep(scope);
            sequence.AddStep(step);

            var assertionStep = CreateTextEqualsAssertionStep(scope);
            sequence.AddStep(assertionStep);

            return sequence;
        }

        private static Step CreateGetFileTextStep(IDataScope scope)
        {
            var step = new Step("Get text from file");
            step.SpecifyScope(scope);

            var getFileAction = CreateGetFileAction(scope);
            step.AddAction(getFileAction);

            var readFileTextAction = CreateReadFileTextAction(scope);
            step.AddAction(readFileTextAction);

            return step;
        }

        private static ActionContext CreateGetFileAction(IDataScope scope)
        {
            var action = new ActionContext<PathData, FileData>(new GetFileAction());
            action.SpecifyScope(scope);
            action.IdentifyInput("path");
            action.IdentifyOutput("file");

            return action;
        }

        private static ActionContext CreateReadFileTextAction(IDataScope scope)
        {
            var action = new ActionContext<FileData, TextData>(new ReadFileTextAction());
            action.SpecifyScope(scope);
            action.IdentifyInput("file");
            action.IdentifyOutput("text");

            return action;
        }

        private static AssertionStep CreateTextEqualsAssertionStep(IDataScope scope)
        {
            var assertionStep = new AssertionStep("Assert text is not empty");
            assertionStep.SpecifyScope(scope);

            var notEmptyAssertion = CreateTextNotEmptyAssertion(scope);
            assertionStep.AddAssertion(notEmptyAssertion);

            var equalsAssertion = CreateTextEqualsAssertion(scope);
            assertionStep.AddAssertion(equalsAssertion);

            return assertionStep;
        }

        private static AssertionContext CreateTextNotEmptyAssertion(IDataScope scope)
        {
            var assertion = new PlainAssertionContext<TextData>(new TextNotEmptyAssertion());
            assertion.SpecifyScope(scope);
            assertion.IdentifyInput("text");

            return assertion;
        }

        private static AssertionContext CreateTextEqualsAssertion(IDataScope scope)
        {
            var assertion = new ExpectationAssertionContext<TextData>(new TextEqualsAssertion());
            assertion.SpecifyScope(scope);
            assertion.IdentifyInput("text");
            assertion.IdentifyExpectation("expectedText");

            return assertion;
        }
    }
}
