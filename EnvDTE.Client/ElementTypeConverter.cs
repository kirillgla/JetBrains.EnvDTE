﻿using System;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Ast;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client
{
    // TODO: share this between client and host?
    public static class ElementTypeConverter
    {
        public static Type GetEnvDTEType(int id) => Dictionary[id].EnvDTEType;
        public static Type GetPsiType(int id) => Dictionary[id].PsiType;
        public static int GetIdByEnvDTEType(Type envDTEType) => throw new NotImplementedException();
        public static int GetIdByPsiType(Type psiType) => throw new NotImplementedException();

        static ElementTypeConverter()
        {
            Register<CodeNamespaceImpl, ICSharpNamespaceDeclaration>();

            Register<CodeClassImpl, IClassDeclaration>();
            Register<CodeStructImpl, IStructDeclaration>();
            Register<CodeInterfaceImpl, IInterfaceDeclaration>();

            Register<CodeFunctionImpl, IMethodDeclaration>();
        }

        private static int CurrentId { get; set; }

        private static IDictionary<int, ElementDescription> Dictionary { get; } =
            new Dictionary<int, ElementDescription>();

        private static void Register<EnvDTEType, PsiType>()
        {
            Dictionary.Add(CurrentId, new ElementDescription(CurrentId, typeof(EnvDTEType), typeof(PsiType)));
            CurrentId += 1;
        }

        [NotNull]
        public static CodeElement ConvertNamespace([NotNull] this NamespaceModel model) =>

        public
    }
}
