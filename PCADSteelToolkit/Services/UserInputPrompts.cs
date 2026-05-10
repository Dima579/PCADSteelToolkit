using IntelliCAD.EditorInput;

namespace PCADSteelToolkit.Services
{
    internal class UserInputPrompts
    {
        //Environment resources provided via DI
        private readonly EnvironmentProvider _environment;
        public UserInputPrompts(EnvironmentProvider environment) {_environment = environment;}

        public string GetStringInput(string prompt, string errorMessage)
        {
            var QuestionPrompt = new PromptStringOptions($"\n{prompt}");
            QuestionPrompt.AllowSpaces = true;
            var userResultString = _environment.Editor.GetString(QuestionPrompt);

            if (userResultString.Status != PromptStatus.OK)
            {
                _environment.Editor.WriteMessage($"\nERROR: {errorMessage}");
                return null;
            }
            else {return userResultString.StringResult;}
        }

        //Returns 2 values (the output value and a status)
        public bool GetDoubleInput(string prompt, string errorMessage, out double value)
        {
            var QuestionPrompt = new PromptDoubleOptions($"\n{prompt}");
            var userResultDouble = _environment.Editor.GetDouble(QuestionPrompt);

            if (userResultDouble.Status != PromptStatus.OK)
            {
                _environment.Editor.WriteMessage($"\nERROR: {errorMessage}");
                value = 0;
                return false;
            }
            else
            {
                value = userResultDouble.Value;
                return true;
            }
        }
    }
}
