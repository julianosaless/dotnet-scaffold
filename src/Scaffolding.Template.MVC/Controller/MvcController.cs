using Microsoft.Extensions.ProjectModel;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Scaffolding.Template.Mvc
{
    public class MvcController
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly ICodeGeneratorActionsService codeGeneratorActionsService;
        private readonly IApplicationInfo applicationInfo;
        private readonly IProjectContext projectContext;

        public MvcController(
            IProjectContext projectContext, IApplicationInfo applicationInfo,
            ICodeGeneratorActionsService codeGeneratorActionsService,
            IServiceProvider serviceProvider, ILogger logger)
        {
            this.projectContext = projectContext;
            this.applicationInfo = applicationInfo;
            this.codeGeneratorActionsService = codeGeneratorActionsService;
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public async Task GenerateAsync(MvcModel model)
        {
            logger.LogMessage("creating controller");
            model.ControllerName = string.Concat(model.ModelClass, Constants.ControllerSuffix);

            logger.LogMessage("creating model controller");

            var templateModel = new ClassNameModel(className: model.ControllerName, namespaceName: NameSpaceUtilities.GetSafeNameSpaceFromPath(applicationInfo.ApplicationBasePath));

            logger.LogMessage("creating files");
            var outputPath = ValidateAndGetOutputPath(model, string.Concat(model.ControllerName, Constants.CodeFileExtension));
            await codeGeneratorActionsService.AddFileFromTemplateAsync(outputPath, Constants.EmptyControllerTemplate, TemplateFolders, templateModel);
        }

        private IEnumerable<string> TemplateFolders
        {
            get
            {
                return TemplateFoldersUtilities.GetTemplateFolders(
                    containingProject: Constants.ThisAssemblyName,
                    applicationBasePath: applicationInfo.ApplicationBasePath,
                    baseFolders: new[] { "Controller", "View" },
                    projectContext: projectContext);
            }
        }

        private string ValidateAndGetOutputPath(MvcModel model, string outputFileName)
        {
            var outputFolder = applicationInfo.ApplicationBasePath;
            var outputPath = Path.Combine(outputFolder, outputFileName);

            if (File.Exists(outputPath) && !model.Force)
            {
                //Todo Need improvement this message
                throw new InvalidOperationException("Existing files");
            }
            return outputPath;
        }
    }
}
