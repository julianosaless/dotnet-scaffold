using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using System;
using System.Threading.Tasks;

namespace Scaffolding.Template.Mvc
{
    [Alias("mvc")]
    public class MvcGenerator : ICodeGenerator
    {
        private readonly IServiceProvider _serviceProvider;

        public MvcGenerator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task GenerateCode(MvcModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrEmpty(model.ModelClass))
                throw new ArgumentNullException(nameof(model.ModelClass));

            var generator = ActivatorUtilities.CreateInstance<MvcController>(_serviceProvider);
            await generator.GenerateAsync(model);
        }
    }
}
