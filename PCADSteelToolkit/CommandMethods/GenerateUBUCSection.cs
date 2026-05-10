using PCADSteelToolkit.Geometry;
using PCADSteelToolkit.Services;
using Teigha.Runtime;

namespace PCADSteelToolkit.CommandMethods
{
    internal class GenerateUBUCSection
    {
        [CommandMethod("GenerateUBUC", CommandFlags.Modal)]
        public static void GenerateUBUC()
        {
            //Inject Db, ProgeCAD Resources and Input Methods 
            var environment = new EnvironmentProvider();
            var prompt = new UserInputPrompts(environment);

            //Section Type Input
            var userSTResult = prompt.GetStringInput($"\nSpecify the Section Type", $"\nInvalid Section Type");

            //Section Designation Input
            var userSDResult = prompt.GetStringInput($"\nSpecify the Section Designation", $"\nInvalid Section Designation");

            //Mass Designation Input
            var userMDResult = prompt.GetStringInput($"\nSpecify the Mass Designation", $"\nInvalid Mass Designation");

            //Db Method call and confirmation
            var section = environment.dbAccess.GetUBUC(userSTResult, userSDResult, userMDResult);
            environment.Editor.WriteMessage($"\nUBUC Retrieved: {userSTResult} {section.SectionDesignation} / {section.MassDesignation}");

            //Section Generation
            var generator = new UBUCGenerator();
            generator.Generate(section);
            environment.Editor.WriteMessage($"\nSection Generated");
        }
    }
}
