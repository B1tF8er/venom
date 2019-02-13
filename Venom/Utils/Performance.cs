namespace Venom
{
    using System;
    using System.Diagnostics;

    internal static class Performance
    {
        internal static void Measure(this string actionName, Action action)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            action();
            stopwatch.Stop();

            Console.WriteLine($"{actionName} took {stopwatch.ElapsedMilliseconds / 1000m} sec");
        }
    }
}
