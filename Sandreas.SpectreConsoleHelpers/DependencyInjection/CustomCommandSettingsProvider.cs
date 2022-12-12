using Spectre.Console.Cli;

namespace Sandreas.SpectreConsoleHelpers.DependencyInjection;


public class CustomCommandSettingsProvider
{
    public CommandSettings? Settings { get; set; }

    public T? Get<T>() where T: class
    {
        if (Settings is T s)
        {
            return s;
        }
        return null;
    }
    
    public TReturn? Build<TSettings,TReturn>(Func<TSettings, TReturn> func) where TSettings: class
    {
        var settings = Get<TSettings>();
        return settings != null ? func(settings) : default;
    }    
    
    public CustomCommandSettingsProvider Append<TReturn, TSettings>(ref List<TReturn> taggers, Func<TSettings, TReturn> func)
    {
        if (Settings is TSettings s)
        {
            taggers.Add(func(s));
        }

        return this;
    }
}