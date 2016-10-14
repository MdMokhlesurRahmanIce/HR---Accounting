using System;
using System.Threading;

namespace ASL.Web.Framework
{
    public static class StaticRandom
    {
        private static int seed;

        private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref seed)));

        static StaticRandom()
        {
            seed = Environment.TickCount;
        }

        public static Random Instance { get { return threadLocal.Value; } }

        public static DateTimeOffset RandomOutTime(this DateTimeOffset value, TimeSpan timeSpan)
        {
            double seconds = timeSpan.TotalSeconds * StaticRandom.Instance.NextDouble();

            //Alternatively: 
            return value.AddSeconds(seconds);
            //TimeSpan span = TimeSpan.FromSeconds(seconds);
            //return value - span;
        }
        public static DateTimeOffset RandomInTime(this DateTimeOffset value, TimeSpan timeSpan)
        {
            double seconds = timeSpan.TotalSeconds * StaticRandom.Instance.NextDouble();

            //Alternatively: 
            return value.AddSeconds(-seconds);
            //TimeSpan span = TimeSpan.FromSeconds(seconds);
            //return value - span;
        }
    }
}



