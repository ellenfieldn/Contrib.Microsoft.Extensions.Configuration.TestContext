// Copyright (c) Nathan Ellenfield. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.Configuration.Contrib.TestContext
{
    /// <summary>
    /// Represents data in an <see cref="IConfiguration"/> as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class TestContextConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The underlying configuration.
        /// </summary>
        public VisualStudio.TestTools.UnitTesting.TestContext TestContext { get; set; }

        /// <summary>
        /// Builds the <see cref="TestContextConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="TestContextConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new TestContextConfigurationProvider(this);
    }
}
