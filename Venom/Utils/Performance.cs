namespace Venom
{
    using Bit.Logger.Contract;
    using System;
    using System.Diagnostics;

    internal class Performance
    {
        private readonly ILogger logger;

        internal Performance(ILogger logger) => this.logger = logger;

        internal void Measure(Data data)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            data.Action();
            stopwatch.Stop();

            var seconds = stopwatch.ElapsedMilliseconds / 1000m;
            logger.Information($"[{data.ClassName}.{data.MethodName}] Took {seconds} sec");
        }
    }
}
