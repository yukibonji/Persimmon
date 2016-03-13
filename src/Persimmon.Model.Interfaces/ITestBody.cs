using System;
using System.Collections.Generic;
using System.Text;

namespace Persimmon.Model.Interfaces
{
    /// <summary>
    /// This type represents the body part of a test computation expression.
    /// If opening UseNameByReflection module,
    /// this type represents the whole part of a test computation expression.
    /// This type is not testable because it does not have metadata.
    /// </summary>
    /// <remarks>
    /// ITestBody = ITestCase - IResusableTestMetadata
    /// </remarks>
    public interface ITestBody : ITestMarker
    {
        /// <summary>
        /// Build ITestCase object.
        /// </summary>
        /// <param name="metadata">metadata</param>
        /// <returns>ITestCase object</returns>
        ITestCase BuildTestCase(IReusableTestMetadata metadata);
    }
}
