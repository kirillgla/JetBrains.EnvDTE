using System;
using System.Collections;
using System.Collections.Generic;
using com.jetbrains.rider.model;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Core.Impl
{
    public sealed class ProjectsImplementation : Projects
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull, ItemNotNull]
        private IReadOnlyList<ProjectModel> Projects { get; }

        public ProjectsImplementation(
            [NotNull] DteImplementation implementation,
            [NotNull, ItemNotNull] IReadOnlyList<ProjectModel> projects
        )
        {
            Implementation = implementation;
            Projects = projects;
        }

        [NotNull]
        public DTE Parent => Implementation;

        public int Count => Projects.Count;

        [NotNull]
        public DTE DTE => Implementation;

        [NotNull]
        IEnumerator Projects.GetEnumerator() => Projects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Projects.GetEnumerator();

        [NotNull]
        public Project Item(object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            return new ProjectImplementation(Implementation, Projects[number]);
        }

        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();
    }
}