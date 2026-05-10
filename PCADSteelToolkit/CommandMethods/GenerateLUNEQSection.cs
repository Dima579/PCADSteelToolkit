using PCADSteelToolkit.Geometry;
using PCADSteelToolkit.Services;
using Teigha.Runtime;

namespace PCADSteelToolkit.CommandMethods
{
    internal class GenerateLUNEQSection
    {
        [CommandMethod("GenerateLUNEQ", CommandFlags.Modal)]
        public static void GenerateLUNEQ()
        {
            //Inject Db, ProgeCAD Resources and Input Methods 
            var environment = new EnvironmentProvider();
            var prompt = new UserInputPrompts(environment);

            //HB Size Input
            var userHBSResult = prompt.GetStringInput($"\nSpecify the Section Designation", $"\nInvalid HB size");

            //Outside Diameter Input
            if (!prompt.GetDoubleInput($"\nSpecify the Outside Diameter in millimetres", $"\nInvalid Thickness Designation", out double ThicknessDesignation)) return;

            //Db Method call and confirmation
            var section = environment.dbAccess.GetLUNEQ(userHBSResult, ThicknessDesignation);
            environment.Editor.WriteMessage($"\nLUNEQ Retrieved: {section.SectionDesignation} / {section.ThicknessDesignation}");

            //Section Generation
            var generator = new LUNEQGenerator();
            generator.Generate(section);
            environment.Editor.WriteMessage($"\nSection Generated");
        }
    }
}
