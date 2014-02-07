﻿// <copyright file="WaitingSteps.cs">
//    Copyright © 2013 Dan Piessens.  All rights reserved.
// </copyright>
namespace SpecBind
{
    using System;

    using SpecBind.ActionPipeline;
    using SpecBind.Actions;
    using SpecBind.Helpers;

    using TechTalk.SpecFlow;

    /// <summary>
    /// A set of step definitions that allow the user to wait for a given condition.
    /// </summary>
    [Binding]
    public class WaitingSteps : PageStepBase
    {
        // Step regex values - in constants because they are shared.
        private const string TimeoutClause = @" (for \d+ seconds?)";
        private const string WaitToSeeElementRegex = @"I wait to see (.+)";
        private const string WaitToNotSeeElementRegex = @"I wait to not see (.+)";
        private const string WaitForElementEnabledRegex = @"I wait for (.+) to become enabled";
        private const string WaitForElementNotEnabledRegex = @"I waited for (.+) to become disabled";
        private const string WaitForActiveViewRegex = @"I wait for the view to become active";

        // The following Regex items are for the given "past tense" form
        private const string GivenWaitToSeeElementRegex = @"I waited to see (.+)";
        private const string GivenWaitToNotSeeElementRegex = @"I waited to not see (.+)";
        private const string GivenWaitForElementEnabledRegex = @"I waited for (.+) to become enabled";
        private const string GivenWaitForElementNotEnabledRegex = @"I waited for (.+) to become disabled";
        private const string GivenWaitForActiveViewRegex = @"I waited for the view to become active";

        private readonly IActionPipelineService actionPipelineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertBoxSteps"/> class.
        /// </summary>
        /// <param name="actionPipelineService">The action pipeline service.</param>
        /// <param name="scenarioContext">The scenario context.</param>
        public WaitingSteps(IActionPipelineService actionPipelineService, IScenarioContextHelper scenarioContext)
            : base(scenarioContext)
        {
            this.actionPipelineService = actionPipelineService;
        }

        /// <summary>
        /// Transforms the wait time to timeout.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns>The translated timespan result.</returns>
        [StepArgumentTransformation(@"for (\d+) seconds?")]
        public TimeSpan TransformWaitTimeToTimeout(int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// A step that waits to see an element.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Given(GivenWaitToSeeElementRegex)]
        [When(WaitToSeeElementRegex)]
        [Then(WaitToSeeElementRegex)]
        public void WaitToSeeElement(string propertyName)
        {
            this.CallPipelineAction(propertyName, WaitConditions.Exists, null);
        }

        /// <summary>
        /// A step that waits to see an element.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="timeout">The timeout for waiting.</param>
        [Given(GivenWaitToSeeElementRegex + TimeoutClause)]
        [When(WaitToSeeElementRegex + TimeoutClause)]
        [Then(WaitToSeeElementRegex + TimeoutClause)]
        public void WaitToSeeElement(string propertyName, TimeSpan timeout)
        {
            this.CallPipelineAction(propertyName, WaitConditions.Exists, timeout);
        }

        /// <summary>
        /// A step that waits to not see an element.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Given(GivenWaitToNotSeeElementRegex)]
        [When(WaitToNotSeeElementRegex)]
        [Then(WaitToNotSeeElementRegex)]
        public void WaitToNotSeeElement(string propertyName)
        {
            this.CallPipelineAction(propertyName, WaitConditions.NotExists, null);
        }

        /// <summary>
        /// A step that waits to not see an element.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="timeout">The timeout for waiting.</param>
        [Given(GivenWaitToNotSeeElementRegex + TimeoutClause)]
        [When(WaitToNotSeeElementRegex + TimeoutClause)]
        [Then(WaitToNotSeeElementRegex + TimeoutClause)]
        public void WaitToNotSeeElement(string propertyName, TimeSpan timeout)
        {
            this.CallPipelineAction(propertyName, WaitConditions.NotExists, timeout);
        }

        /// <summary>
        /// A step that waits for an element to be enabled.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Given(GivenWaitForElementEnabledRegex)]
        [When(WaitForElementEnabledRegex)]
        [Then(WaitForElementEnabledRegex)]
        public void WaitForElementEnabled(string propertyName)
        {
            this.CallPipelineAction(propertyName, WaitConditions.Enabled, null);
        }

        /// <summary>
        /// A step that waits for an element to be enabled.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="timeout">The timeout for waiting.</param>
        [Given(GivenWaitForElementEnabledRegex + TimeoutClause)]
        [When(WaitForElementEnabledRegex + TimeoutClause)]
        [Then(WaitForElementEnabledRegex + TimeoutClause)]
        public void WaitForElementEnabled(string propertyName, TimeSpan timeout)
        {
            this.CallPipelineAction(propertyName, WaitConditions.Enabled, timeout);
        }

        /// <summary>
        /// A step that waits for an element to be not enabled.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Given(GivenWaitForElementNotEnabledRegex)]
        [When(WaitForElementNotEnabledRegex)]
        [Then(WaitForElementNotEnabledRegex)]
        public void WaitForElementNotEnabled(string propertyName)
        {
            this.CallPipelineAction(propertyName, WaitConditions.NotEnabled, null);
        }

        /// <summary>
        /// A step that waits for an element to be not enabled.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="timeout">The timeout for waiting.</param>
        [Given(GivenWaitForElementNotEnabledRegex + TimeoutClause)]
        [When(WaitForElementNotEnabledRegex + TimeoutClause)]
        [Then(WaitForElementNotEnabledRegex + TimeoutClause)]
        public void WaitForElementNotEnabled(string propertyName, TimeSpan timeout)
        {
            this.CallPipelineAction(propertyName, WaitConditions.NotEnabled, timeout);
        }

        /// <summary>
        /// I wait for the view to be active step.
        /// </summary>
        [Given(GivenWaitForActiveViewRegex)]
        [When(WaitForActiveViewRegex)]
        public void WaitForTheViewToBeActive()
        {
            var page = this.GetPageFromContext();
            page.WaitForPageToBeActive();
        }

        /// <summary>
        /// Calls the pipeline action.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="expectedCondition">The expected condition.</param>
        /// <param name="timeout">The timeout for waiting.</param>
        private void CallPipelineAction(string propertyName, WaitConditions expectedCondition, TimeSpan? timeout)
        {
            var page = this.GetPageFromContext();

            var context = new WaitForElementAction.WaitForElementContext(propertyName.ToLookupKey(), expectedCondition, timeout);
            this.actionPipelineService.PerformAction<WaitForElementAction>(page, context).CheckResult();
        }
    }
}