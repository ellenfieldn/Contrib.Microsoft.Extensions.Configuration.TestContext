// Copyright (c) Nathan Ellenfield. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration;
using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contrib.Microsoft.Extensions.Configuration.TestContext
{
    /// <summary>
    /// Represents data in an <see cref="IConfiguration"/> as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class TestContextConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The underlying configuration.
        /// </summary>
        public MSTest.TestContext TestContext { get; set; }

        /// <summary>
        /// Builds the <see cref="TestContextConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="TestContextConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new TestContextConfigurationProvider(this);
    }
}
