using System;
using System.Collections.Generic;
using System.Text;

namespace Persimmon.Model.Interfaces
{
    /// <summary>
    /// The location of the ITestable object and ITestResult object.
    /// These have location for jumping to declaration from GUI Test Adapter.
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// The file path that contains the ITestable object.
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// The line number of the ITestable object.
        /// This property is 1 origin.
        /// </summary>
        int LineNumber { get; }
    }

    /// <summary>
    /// The common metadata of ITestable object and ITestResult object.
    /// </summary>
    public interface ITestMetadata
    {
        /// <summary>
        /// The test name.
        /// This property does not have information of parameters.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The location information in code.
        /// </summary>
        ILocation Location { get; }

        /// <summary>
        /// The properties about trait of test.
        /// This property can use to filter tests by user defined trait.
        /// We can use this property for filtering tests by user defined trait.
        /// For example, this property will have "SlowTest", "DatabaseTest" and so on.
        /// </summary>
        string[] Proerties { get; }
    }

    /// <summary>
    /// The metadata of reusable test(ITestCase and ITestCaseResult).
    /// </summary>
    public interface IReusableTestMetadata : ITestMetadata
    {
        /// <summary>
        /// The index of binding in test computation expression.
        /// </summary>
        int Index { get; }
    }

    /// <summary>
    /// This type represents one parameter of parameterized test.
    /// </summary>
    public interface ITestParameter
    {
        /// <summary>
        /// The parameter name.
        /// This property will be null if not given name.
        /// </summary>
        string NameOrNull { get; }

        /// <summary>
        /// The parameter type.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// The parameter value.
        /// </summary>
        object Value { get; }
    }

    /// <summary>
    /// The metadata of test parameters(ITestCaseWithParameters and ITestCaseResultWithParameters).
    /// </summary>
    public interface ITestParametersMetadata : ITestMetadata
    {
        /// <summary>
        /// The test parameters.
        /// </summary>
        ITestParameter[] TestParameters { get; }
    }
}
