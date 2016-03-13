using System;
using System.Collections.Generic;
using System.Text;

namespace Persimmon.Model.Interfaces
{
    /// <summary>
    /// The test result.
    /// After running tests, the ITestable objects become the ITestResult objects.
    /// </summary>
    public interface ITestResult
    {
        /// <summary>
        /// The metadata of test.
        /// </summary>
        ITestMetadata Metadata { get; }

        /// <summary>
        /// The duration of running test.
        /// </summary>
        TimeSpan Duration { get; }
    }

    /// <summary>
    /// The collection of ITestResult objects.
    /// After running tests, the ITestGroup objects become the ITestGroupResult objects.
    /// </summary>
    public interface ITestGroupResult : ITestResult
    {
        /// <summary>
        /// The child ITestResult objects.
        /// </summary>
        ITestResult[] Children { get; }
    }

    /// <summary>
    /// The result of each tests.
    /// After running tests, the ITestCase objects become the ITestResult objects.
    /// </summary>
    public interface ITestCaseResult : ITestResult
    {
        /// <summary>
        /// The exceptions that are happend while the test case is executing.
        /// </summary>
        Exception[] Exceptions { get; }

        /// <summary>
        /// The duration of running test.
        /// If a test was shared,
        /// Duration property returns duration that a test is run actually
        /// but DurationForSummary property returns duration that a test result is returned from cache.
        /// So DurationForSummary property may return shorter duration than the value of Duration property.
        /// If you will summary duration from test results,
        /// you should use this property instead of Duration property.
        /// </summary>
        TimeSpan DurationForSummary { get; }
    }

    /// <summary>
    /// The result of each tests with parameters.
    /// After running tests, the ITestCaseWithParameters objects become the ITestResultWithParameters objects.
    /// </summary>
    public interface ITestCaseResultWithParameters : ITestResult
    {
        /// <summary>
        /// The test case result.
        /// </summary>
        ITestCaseResult TestCaseResult { get; }
    }

    /// <summary>
    /// The result of each parameterized tests.
    /// After running tests, the IParameterizedTest objects become the IParameterizedTestResult objects.
    /// </summary>
    public interface IParameterizedTestResult : ITestResult
    {
        /// <summary>
        /// The test case result.
        /// </summary>
        ITestCaseResultWithParameters[] TestCaseResults { get; }
    }
}
