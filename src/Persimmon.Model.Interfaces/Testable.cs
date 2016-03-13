using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Persimmon.Model.Interfaces
{
    /// <summary>
    /// The invoker that is calling test.
    /// </summary>
    public enum TestInvoker
    {
        Persimmon = 0,
        TestGroup = 0,
        OtherTest = 1 // this represents reusing of test
    }

    /// <summary>
    /// This type represents a testable object that has not been run yet.
    /// In order to run the test represented this type, use the "RunTest" method.
    /// </summary>
    public interface ITestable : ITestMarker
    {
        /// <summary>
        /// The metadata of test.
        /// </summary>
        ITestMetadata Metadata { get; }

        /// <summary>
        /// Run test. This returns the results of test.
        /// </summary>
        /// <remarks>
        /// This method should have backing lazy field to reuse test results.
        /// </remarks>
        /// <param name="invoker">The value of TestInvoker that invokes this method.</param>
        /// <returns>The results of test.</returns>
        ITestResult[] RunTest(TestInvoker invoker);
    }

    /// <summary>
    /// The collection of ITestable objects.
    /// This type represents a test group that has not been run yet.
    /// We can use this type for grouping of the tests.
    /// </summary>
    public interface ITestGroup : ITestable
    {
        /// <summary>
        /// The child ITestable objects.
        /// </summary>
        ITestable[] Children { get; }
    }

    /// <summary>
    /// This type represents a test case that has not been run yet.
    /// This type is *leaf node* of ITestable type hierarchy.
    /// Metadata property of this type returns IResusableTestMetadata object.
    /// </summary>
    public interface ITestCase : ITestable
    {
        /// <summary>
        /// The test body.
        /// </summary>
        ITestBody Body { get; }
    }

    /// <summary>
    /// This type represents a test case with parameters that has not been run yet.
    /// Metadata property of this type returns ITestParametersMetadata object.
    /// </summary>
    public interface ITestCaseWithParameters : ITestable
    {
        /// <summary>
        /// The test case.
        /// </summary>
        ITestCase TestCase { get; }
    }

    /// <summary>
    /// This type represents a parameterized test that has not been run yet.
    /// </summary>
    public interface IParameterizedTest : ITestable
    {
        /// <summary>
        /// The test cases with parameters.
        /// </summary>
        ITestCaseWithParameters[] TestCases { get; }
    }
}
