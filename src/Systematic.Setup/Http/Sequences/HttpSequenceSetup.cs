namespace Systematic.Setup.Http.Sequences
{
    using System;
    using System.Collections.Generic;

    using Systematic;
    using Systematic.Data.Scope;
    using Systematic.Http.Scope;
    using Systematic.Setup.Data;
    using Systematic.Setup.Http.Steps;
    using Systematic.Setup.Sequences;
    using Systematic.Setup.Steps;

    /// <summary>
    /// A setup of a sequence that can only contain HTTP and simple step setups.
    /// </summary>
    public class HttpSequenceSetup : SequenceSetup, ISequenceSetup<ISimpleStepSetup>, ISequenceSetup<IHttpStepSetup>
    {
        /// <summary>
        /// An HTTP scope setup registry.
        /// </summary>
        private readonly IHttpScopeSetupRegistry _httpScopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSequenceSetup"/> class.
        /// </summary>
        /// <param name="scopes">A data scope setup registry.</param>
        /// <param name="httpScopes">An HTTP scope setup registry.</param>
        public HttpSequenceSetup(IDataScopeSetupRegistry scopes, IHttpScopeSetupRegistry httpScopes)
            : base(scopes)
        {
            _httpScopes = httpScopes;
        }

        /// <summary>
        /// Gets or sets an ID of an HTTP scope in which the sequence resides.
        /// </summary>
        public ScopeIdentifier HttpScope { get; set; }

        /// <inheritdoc />
        public void AddStep(ISimpleStepSetup setup) => MutableSteps.Add(setup);

        /// <inheritdoc />
        public void RemoveStep(ISimpleStepSetup setup) => MutableSteps.Remove(setup);

        /// <inheritdoc />
        public void AddStep(IHttpStepSetup setup) => MutableSteps.Add(setup);

        /// <inheritdoc />
        public void RemoveStep(IHttpStepSetup setup) => MutableSteps.Remove(setup);

        /// <inheritdoc />
        protected override IEnumerable<Step> BuildSteps()
        {
            var scope = BuildScope();
            var httpScope = BuildHttpScope();

            foreach (var setup in Steps)
                yield return BuildStep(setup, scope, httpScope);
        }

        /// <summary>
        /// Builds a step.
        /// </summary>
        /// <param name="setup">A step setup.</param>
        /// <param name="scope">A data scope.</param>
        /// <param name="httpScope">An HTTP scope.</param>
        /// <returns>A step.</returns>
        private static Step BuildStep(IStepSetup setup, IDataScope scope, IHttpScope httpScope)
        {
            return setup switch
            {
                IHttpStepSetup httpSetup => httpSetup.Build(scope, httpScope),
                ISimpleStepSetup simpleSetup => simpleSetup.Build(scope),
                _ => throw new InvalidOperationException("Steps of an HTTP sequence must be HTTP or simple only.")
            };
        }

        /// <summary>
        /// Builds an HTTP scope in which the sequence resides.
        /// </summary>
        /// <returns>An HTTP scope.</returns>
        /// <exception cref="InvalidOperationException">An HTTP scope id must be set prior to build.</exception>
        private IHttpScope BuildHttpScope()
        {
            if (HttpScope == default)
                throw new InvalidOperationException("An HTTP scope id must be set prior to build.");

            var scopeSetup = _httpScopes.Get(HttpScope);
            return scopeSetup.Build();
        }
    }
}
