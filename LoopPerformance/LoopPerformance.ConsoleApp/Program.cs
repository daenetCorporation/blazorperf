using System;
using LoopPerformanceLib;

namespace LoopPerformance.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int sampleCount = 10000;

            Helpers.SampleRun(sampleCount);
            sampleCount = 20000;

            Helpers.SampleRun(sampleCount);
            sampleCount = 30000;

            Helpers.SampleRun(sampleCount);
        }
    }
}
