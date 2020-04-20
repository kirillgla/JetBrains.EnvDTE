using JetBrains.Annotations;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class CodeFunctionCallbackProvider : CodeElementCallbackProviderBase
    {
        protected override void DoRegisterCallbacks(ProjectModelViewHost host, DteProtocolModel model)
        {
            MapWithAstManager<IFunctionDeclaration, IFunction, CodeElementModel>(
                model.CodeFunction_get_Type,
                node => CreateTypeModel(node.DeclaredElement.NotNull()),
                CreateTypeModel
            );
        }

        [CanBeNull]
        private CodeElementModel CreateTypeModel([NotNull] IFunction function) =>
            ToModel(function.ReturnType.NotNull().GetTypeElement().NotNull());
    }
}
