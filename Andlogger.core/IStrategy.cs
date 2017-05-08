namespace Andlogger
{
    public interface IStrategy
    {
        void Save(Level level, string log);
    }

    public enum Type
    {
        File
    }

    public enum Level
    {
        Debug,
        Info,
        Warning,
        Error
    }
}