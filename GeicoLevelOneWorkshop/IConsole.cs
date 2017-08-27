namespace GeicoLevelOneWorkshop
{
    public interface IConsole
    {
        string ReadLine();
        void Write(string message);
        void WriteLine();
        void WriteLine(string message);
        void WriteLine(string format, params object[] args);
        void WriteLine(object obj);
 
    }
}