using PCADSteelToolkit.Geometry;
using Teigha.DatabaseServices;

namespace PCADSteelToolkit.Services
{
    internal class SectionDispatcher
    {
        private readonly EnvironmentProvider _environment;
        public SectionDispatcher(EnvironmentProvider environment) { _environment = environment; }

        internal void DispatchSections(string userInput) 
        {

            var inputValues = userInput.Split('/');

            var secTypeVal = inputValues[0].Trim();
            var secVal1 = inputValues[1].Trim();
            var secVal2 = inputValues[2].Trim();

            
            switch(inputValues[0])
            {
                case "HFCH":
                    {
                        double val1Conv = double.Parse(secVal1);
                        double val2Conv = double.Parse(secVal2);

                        var section = _environment.dbAccess.GetHFCH(val1Conv, val2Conv);
                        var generator = new HFCHGenerator();
                        generator.Generate(section);
                        break;
                    }

                case "HFRH":
                    {
                        double val2Conv = double.Parse(secVal2);

                        var section = _environment.dbAccess.GetHFRH(secVal1, val2Conv);
                        var generator = new HFRHGenerator();
                        generator.Generate(section);
                        break;
                    }

                case "LUNEQ":
                    {
                        double val2Conv = double.Parse(secVal2);

                        var section = _environment.dbAccess.GetLUNEQ(secVal1, val2Conv);
                        var generator = new LUNEQGenerator();
                        generator.Generate(section);
                        break;
                    }

                case "UB":
                case "UC":
                    {
                        var section = _environment.dbAccess.GetUBUC(secTypeVal, secVal1, secVal2);
                        var generator = new UBUCGenerator();
                        generator.Generate(section);
                        break;
                    }

                default:
                    {
                        _environment.Editor.WriteMessage("\nERROR: Invalid Section Type");
                        break;
                    }
            }
            return;
        }
    }
}
