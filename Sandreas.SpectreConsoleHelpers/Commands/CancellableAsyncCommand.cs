using Spectre.Console.Cli;

namespace Sandreas.SpectreConsoleHelpers.Commands;

public abstract class CancellableAsyncCommand<TSettings> : AsyncCommand<TSettings>
    where TSettings : CommandSettings
{
    private readonly ConsoleAppCancellationTokenSource _cancellationTokenSource = new();

    public abstract Task<int> ExecuteAsync(CommandContext context, TSettings settings, CancellationToken cancellation);

    public sealed override async Task<int> ExecuteAsync(CommandContext context, TSettings settings) => await ExecuteAsync(context, settings, _cancellationTokenSource.Token);
}