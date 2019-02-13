namespace Venom
{
    using System;
    using System.Diagnostics;

    internal static class Performance
    {
        internal static void Measure(this string name, Action action)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            action();
            stopwatch.Stop();

            var seconds = stopwatch.ElapsedMilliseconds / 1000m;
            Console.WriteLine($"{name} took {seconds} seconds");
        }
    }
}
