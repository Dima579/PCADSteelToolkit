using PCADSteelToolkit.Geometry;
using PCADSteelToolkit.Services;
using Teigha.Runtime;

namespace PCADSteelToolkit.CommandMethods
{
    internal class GenerateHFRHSection
    {
        [CommandMethod("GenerateHFRH", CommandFlags.Modal)]
        public static void GenerateHFRH()
        {
            //Inject Db, ProgeCAD Resources and Input Methods 
            var environment = new EnvironmentProvider();
            var prompt = new UserInputPrompts(environment);

            //HB Size Input
            var userHBSResult = prompt.GetStringInput($"\nSpecify the HB size in millimetres", $"\nInvalid HB size");

            //Thickness Designation Input
            if (!prompt.GetDoubleInput($"\nSpecify the Thickness Designation", $"\nInvalid Thickness Designation", out double thicknessDesignation)) return;

            //Db Method call and confirmation
            var section = environment.dbAccess.GetHFRH(userHBSResult, thicknessDesignation);
            environment.Editor.WriteMessage($"\nHFRH Retrieved: {section.SizeHB_mm} / {section.ThicknessDesignation}");

            //Section Generation
            var generator = new HFRHGenerator();
            generator.Generate(section);
            environment.Editor.WriteMessage($"\nSection Generated");
        }
    }
}
