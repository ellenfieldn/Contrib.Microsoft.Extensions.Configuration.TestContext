// Copyright (c) Nathan Ellenfield. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contrib.Microsoft.Extensions.Configuration.TestContext
{
    /// <summary>
    /// Implementation of <see cref="IConfigurationProvider"/> that supports TestContext-based configuration.
    /// </summary>
    public class TestContextConfigurationProvider : ConfigurationProvider
    {
        private readonly MSTest.TestContext _testContext;

        /// <summary>
        /// Initializes a new instance from the source configuration.
        /// </summary>
        /// <param name="source">The source configuration.</param>
        public TestContextConfigurationProvider(TestContextConfigurationSource source)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            _testContext = source.TestContext ?? throw new ArgumentNullException(nameof(source.TestContext));
        }

        /// <summary>
        /// Loads configuration values from the source represented by this <see cref="IConfigurationProvider"/>.
        /// </summary>
        public override void Load() 
        {
            Data = _testContext.Properties
                .Cast<KeyValuePair<string, object>>()
                .ToDictionary(p => p.Key, p => p.Value.ToString(), StringComparer.OrdinalIgnoreCase);
        }
    }
}
