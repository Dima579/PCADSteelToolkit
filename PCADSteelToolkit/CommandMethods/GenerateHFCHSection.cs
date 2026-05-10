using Teigha.Runtime;
using PCADSteelToolkit.Geometry;
using PCADSteelToolkit.Services;

namespace PCADSteelToolkit.CommandMethods
{
    internal class GenerateHFCHSection
    {
        [CommandMethod("GenerateHFCH", CommandFlags.Modal)]
        public static void GenerateHFCH()
        {
            //Inject Db, ProgeCAD Resources and Input Methods 
            var environment = new EnvironmentProvider();
            var prompt = new UserInputPrompts(environment);

            //Outside Diameter Input
            if (!prompt.GetDoubleInput($"\nSpecify the Outside Diameter in millimetres", $"\nInvalid Outside Diameter", out double outsideDiameter)) return;

            //Thickness Designation Input
            if (!prompt.GetDoubleInput($"\nSpecify the Thickness Designation", $"\nInvalid Thickness Designation", out double thicknessDesignation)) return;

            //Db Method call and confirmation
            var section = environment.dbAccess.GetHFCH(outsideDiameter, thicknessDesignation);
            environment.Editor.WriteMessage($"\nHFCH Retrieved: {section.OutsideDiameter_mm} / {section.ThicknessDesignation}");

            //Section Generation
            var generator = new HFCHGenerator();
            generator.Generate(section);
            environment.Editor.WriteMessage($"\nSection Generated");
        }
    }
}
