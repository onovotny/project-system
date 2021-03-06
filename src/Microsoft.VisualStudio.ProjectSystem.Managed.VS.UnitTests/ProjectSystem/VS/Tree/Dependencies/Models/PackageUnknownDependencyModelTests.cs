﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.ProjectSystem.VS.Tree.Dependencies.Models;
using Microsoft.VisualStudio.ProjectSystem.VS.Tree.Dependencies.Snapshot;
using Xunit;

namespace Microsoft.VisualStudio.ProjectSystem.VS.Tree.Dependencies
{
    [ProjectSystemTrait]
    public class PackageUnknownDependencyModelTests
    {
        [Fact]
        public void Resolved()
        {
            var properties = ImmutableDictionary<string, string>.Empty.Add("myProp", "myVal");
            var dependencyIDs = new[] { "id1", "id2" };

            var flag = ProjectTreeFlags.Create("MyCustomFlag");
            var model = new PackageUnknownDependencyModel(
                providerType: "myProvider",
                path: "c:\\myPath",
                originalItemSpec: "myOriginalItemSpec",
                name: "myPath",
                flags: flag,
                resolved:true,
                properties: properties,
                dependenciesIDs: dependencyIDs);

            Assert.Equal("myProvider", model.ProviderType);
            Assert.Equal("c:\\myPath", model.Path);
            Assert.Equal("myPath", model.Name);
            Assert.Equal("myOriginalItemSpec", model.OriginalItemSpec);
            Assert.Equal("myPath", model.Caption);
            Assert.Equal(null, model.SchemaName);
            Assert.Equal(false, model.TopLevel);
            Assert.Equal(true, model.Visible);
            Assert.Equal(true, model.Resolved);
            Assert.Equal(false, model.Implicit);
            Assert.Equal(properties, model.Properties);
            Assert.Equal(Dependency.UnresolvedReferenceNodePriority, model.Priority);
            Assert.Equal(KnownMonikers.QuestionMark, model.Icon);
            Assert.Equal(KnownMonikers.QuestionMark, model.ExpandedIcon);
            Assert.Equal(KnownMonikers.QuestionMark, model.UnresolvedIcon);
            Assert.Equal(KnownMonikers.QuestionMark, model.UnresolvedExpandedIcon);
            Assert.Equal(2, model.DependencyIDs.Count);
            Assert.True(model.Flags.Contains(flag));
        }
    }
}
