namespace GeicoLevelOneWorkshop
{
    using System.Diagnostics.CodeAnalysis;
    
    [ExcludeFromCodeCoverage]
    public class Console : IConsole
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public void Write(string message)
        {
            System.Console.Write(message);
        }
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public void WriteLine()
        {
            this.WriteLine("");
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
