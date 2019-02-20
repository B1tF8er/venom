namespace Venom
{
    using Bit.Logger.Contract;
    using System;
    using System.Diagnostics;

    internal class Performance
    {
        private readonly ILoggerFactory loggerFactory;

        internal Performance(ILoggerFactory loggerFactory) => this.loggerFactory = loggerFactory;

        internal void Measure(Data data)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            data.Action();
            stopwatch.Stop();

            var seconds = stopwatch.ElapsedMilliseconds / 1000m;
            loggerFactory.Information($"[{data.ClassName}.{data.MethodName}] Took {seconds} sec");
        }
    }
}
