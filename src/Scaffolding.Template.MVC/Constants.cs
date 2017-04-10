using System.Reflection;

namespace Scaffolding.Template.Mvc
{
    internal class Constants
    {
        public static readonly string ThisAssemblyName = typeof(Constants).GetTypeInfo().Assembly.GetName().Name;

        public const string ControllerSuffix = "Controller";
        public const string ControllersFolderName = "Controllers";
        public const string ViewsFolderName = "Views";
        public const string SharedViewsFolderName = "Shared";


        public const string ViewExtension = ".cshtml";
        public const string CodeFileExtension = ".cs";
        public const string RazorTemplateExtension = ".cshtml";

        public const string EmptyControllerTemplate = "EmptyController.cshtml";
    }
}
