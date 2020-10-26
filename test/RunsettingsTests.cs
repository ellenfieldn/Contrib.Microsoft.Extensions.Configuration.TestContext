// Copyright (c) Nathan Ellenfield. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContextConfiguration.Tests
{
    [TestClass, TestCategory("Unit Tests"), TestCategory("Acceptance Tests"), TestCategory("Variables")]
    public class TestContextTests
    {
        public static IConfiguration Configuration { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var builder = new ConfigurationBuilder()
                .AddTestContext(testContext);
            Configuration = builder.Build();
        }

        /// <summary>
        /// Retrieve a normal app setting with no variables.
        /// </summary>
        [TestMethod]
        public void NormalSetting()
        {
            Assert.AreEqual("Value1", Configuration["NormalSetting"]);
        }

        /// <summary>
        /// Retrieve an app setting that as a property on a complex object
        /// </summary>
        [TestMethod]
        public void ComplexObject()
        {
            Assert.AreEqual("VarValueInProperty", Configuration["ComplexObject:PropertyOnObject"]);
        }

        /// <summary>
        /// Retrieve an app setting that as a property on a complex object that was automatically deserialized
        /// </summary>
        [TestMethod]
        public void DeserializedComplexObject()
        {
            var appConfig = Configuration.GetSection("ComplexObject").Get<MyPoco>();
            Assert.AreEqual("VarValueInProperty", appConfig.PropertyOnObject);
        }

        /// <summary>
        /// Attempt to retrieve an app setting that does not exist
        /// </summary>
        [TestMethod]
        public void MissingKey()
        {
            Assert.IsNull(Configuration["MissingKey"]);
        }
    }

    public class MyPoco
    {
        public string PropertyOnObject { get; set; }
    }
}