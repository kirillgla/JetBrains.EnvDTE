using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class CodeElementCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            ConnectionManager connectionManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        ) => model.CodeElement_get_Children.SetWithReadLock(codeElementModel =>
        {
            var astManager = connectionManager.AstManagers[codeElementModel.ContainingFile.Id];
            var query =
                from childId in astManager.GetChildren(codeElementModel.Id)
                let child = astManager.GetElement(childId)
                let childTypeId = PsiElementRegistrar.GetTypeId(child)
                let childName = ElementNameProvider.FindName(child)
                select new CodeElementModel(childName, childTypeId, codeElementModel.ContainingFile, childId);
            return query.ToList();
        });
    }
}
