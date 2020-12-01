using System;
using System.Diagnostics;


namespace Argutec.Profiling
{
    /// <summary>
    /// Simple profiler. Usage:
    /// using (new Profiler("MyMethod performance"))
    /// {
    ///     MyMethod();    
    /// }
    /// </summary>
    public class Profiler : IDisposable
    {
        private string mDescription;
        private Stopwatch mStopwatch = new Stopwatch();

        /// <summary>
        /// Starts profiling.
        /// </summary>
        /// <param name="aDescription">Description of the profiler that will be printed into log.</param>
        public Profiler(string aDescription)
        {
            mDescription = aDescription;
            Console.WriteLine($"[..] Task '{mDescription}' started.");
            mStopwatch.Start();
        }

        public void Dispose()
        {
            mStopwatch.Stop();
            TimeSpan lElapsedTime = mStopwatch.Elapsed;

            Console.WriteLine($"[OK] Task '{mDescription}' completed in {lElapsedTime.TotalMilliseconds} ms.");
        }
    }
}
