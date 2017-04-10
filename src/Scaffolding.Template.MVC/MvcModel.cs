using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace Scaffolding.Template.Mvc
{
    public class MvcModel 
    {
        [Option(Name = "model", ShortName = "m", Description = "Specify name of your model")]
        public string ModelClass { get; set; }

        [Option(Name = "force", ShortName = "f", Description = "Use this option to overwrite existing files")]
        public bool Force { get; set; }

        public string ControllerName { get; set; }
    }
}
