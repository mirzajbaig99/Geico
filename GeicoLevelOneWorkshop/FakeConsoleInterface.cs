namespace GeicoLevelOneWorkshop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    [ExcludeFromCodeCoverage]
    public class FakeConsoleInterface : IConsole
    {
        public Queue<string> UserInput;
        public string Output;

        public FakeConsoleInterface(IEnumerable<string> input)
        {
            UserInput = new Queue<string>(input);
            Output = "";
        }

        public string ReadLine()
        {
            if (UserInput.Count == 0)
            {
                return "";
            }

            return UserInput.Dequeue();
        }

        public void Write(string message)
        {
            Output += message;
        }

        public void WriteLine()
        {
            WriteLine("");
        }

        public void WriteLine(string message)
        {
            Output += message + Environment.NewLine;
        }

        public void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        public void WriteLine(object obj)
        {
            WriteLine(obj.ToString());
        }
    }
}
