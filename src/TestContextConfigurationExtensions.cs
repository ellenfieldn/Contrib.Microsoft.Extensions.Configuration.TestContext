// Copyright (c) Nathan Ellenfield. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration.Contrib.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class TestContextConfigurationExtensions
    {
        /// <summary>
        /// Adds the TestContextConfigurationProvider to <paramref name="configurationBuilder"/>.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="config">The source <see cref="IConfiguration" /> to pull data from.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddTestContext(this IConfigurationBuilder configurationBuilder, TestContext testContext)
        {
            configurationBuilder = configurationBuilder ?? throw new ArgumentException(nameof(configurationBuilder));
            testContext = testContext ?? throw new ArgumentException(nameof(testContext));
            configurationBuilder.Add(new TestContextConfigurationSource { TestContext = testContext });
            return configurationBuilder;
        }
    }
}
