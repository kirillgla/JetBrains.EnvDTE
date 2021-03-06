using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host
{
    public static class PsiElementRegistrar
    {
        public const int CLASS_DECLARATION_ID = 2;
        private static IList<(Type, int)> KnownPsiTypes { get; } = new List<(Type, int)>();
        private static IList<(Type, int)> KnownDeclaredTypes { get; } = new List<(Type, int)>();
        private static ISet<Type> TypesToReplaceWithChildren { get; } = new HashSet<Type>();

        /// <summary>
        /// The type id for TType will be set to id.
        /// The same id can later be used by the client
        /// to deduce the type of EnvDTE AST node to create.
        /// </summary>
        private static void RegisterType<TPsi, TDeclared>(int id)
            where TPsi : ITreeNode
            where TDeclared: IDeclaredElement
        {
            KnownPsiTypes.Add((typeof(TPsi), id));
            KnownDeclaredTypes.Add((typeof(TDeclared), id));
        }

        /// <summary>
        /// Same as <see cref="RegisterType{TPsi,TDeclared}(int)"/>,
        /// but for PSI nodes that have no corresponding declared elements.
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="TPsi"></typeparam>
        private static void RegisterType<TPsi>(int id) where TPsi : ITreeNode =>
            KnownPsiTypes.Add((typeof(TPsi), id));

        /// <summary>
        /// Elements that have not been registered are ignored by default.
        /// However, it is sometimes interesting to replace the entire element with its children.
        /// That is the case, for example, for namespaces and classes. The PSI structure of them is the following:
        /// INamespaceDeclaration("ConsoleApplication1")
        ///     INamespaceBody
        ///         IClassDeclaration("Class1")                    (?)
        ///         IClassDeclaration("Class2")
        /// The EnvDTE structure of them is the following:
        /// CodeNamespace("ConsoleApplication1")
        ///     CodeClass("Class1")
        ///     CodeClass("Class2")
        /// </summary>
        private static void ReplaceWithChildren<TType>() => TypesToReplaceWithChildren.Add(typeof(TType));

        static PsiElementRegistrar()
        {
            RegisterType<ICSharpNamespaceDeclaration, INamespace>(1);
            RegisterType<IClassDeclaration, IClass>(CLASS_DECLARATION_ID);
            RegisterType<IStructDeclaration, IStruct>(3);
            RegisterType<IInterfaceDeclaration, IInterface>(4);
            RegisterType<IFunctionDeclaration, IFunction>(5);
            RegisterType<IParameterDeclaration, IParameter>(6);
            RegisterType<IAttribute>(7);

            ReplaceWithChildren<INamespaceBody>();
            ReplaceWithChildren<IClassBody>();
            ReplaceWithChildren<IFormalParameterList>();
            ReplaceWithChildren<IAttributeSection>();
            ReplaceWithChildren<IAttributeSectionList>();
            ReplaceWithChildren<IAttributeList>();
        }

        public static int GetTypeId([NotNull] ITreeNode node)
        {
            foreach (var (type, id) in KnownPsiTypes)
            {
                if (type.IsInstanceOfType(node))
                {
                    return id;
                }
            }

            return 0;
        }

        public static int GetTypeId(IDeclaredElement element)
        {
            foreach (var (type, id) in KnownDeclaredTypes)
            {
                if (type.IsInstanceOfType(element))
                {
                    return id;
                }
            }

            return 0;
        }

        public static bool ShouldAddToModel([NotNull] ITreeNode node) => GetTypeId(node) != 0;

        public static bool ShouldVisitChildren([NotNull] ITreeNode node) =>
            GetTypeId(node) != 0 || TypesToReplaceWithChildren.Any(it => it.IsInstanceOfType(node));
    }
}
