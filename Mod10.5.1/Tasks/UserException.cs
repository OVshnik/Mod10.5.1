using System;
using Task1;

public class UserException : Exception
{
    ILogger logger;
    public UserException(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        logger.Error(message);
    }
    public UserException(ILogger logger)
    {
        this.logger = logger;
    }
    
}
