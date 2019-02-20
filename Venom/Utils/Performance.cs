namespace Venom
{
    using Bit.Logger.Contract;
    using System;
    using System.Diagnostics;

    internal class Performance
    {
        private readonly ILoggerFactory loggerFactory;

        internal Performance(ILoggerFactory loggerFactory) => this.loggerFactory = loggerFactory;

        internal void Measure(Action action, string className, string methodName)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            action();
            stopwatch.Stop();

            loggerFactory.Information($"[{className}.{methodName}] Took {stopwatch.ElapsedMilliseconds / 1000m} sec");
        }
    }
}
