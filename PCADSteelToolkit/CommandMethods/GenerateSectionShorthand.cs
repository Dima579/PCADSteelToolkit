using PCADSteelToolkit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.Runtime;

namespace PCADSteelToolkit.CommandMethods
{
    internal class GenerateSectionShorthand
    {
        [CommandMethod("GenerateSection", CommandFlags.Modal)]
        public static void GenerateSection()
        {
            //Inject Db, ProgeCAD Resources and Input Methods 
            var environment = new EnvironmentProvider();
            var prompt = new UserInputPrompts(environment);

            //Shorthand prompt
            string shorthandData = prompt.GetStringInput("Specify Values (EXAMPLE: VAL1/VAL2/VAL3)", "ERROR: Invalid Values");

            //Generation Code
            var dispatcher = new SectionDispatcher(environment);
            dispatcher.DispatchSections(shorthandData);
            environment.Editor.WriteMessage($"\nSection Generated");
        }
    }
}
