using LoopPerformanceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopPerformance.BlazorWasm.Services
{
    public class LongRunningService
    {
        public bool LongRunningTask(int itemCount)
        {
            Helpers.SampleRun(itemCount);

            return true;
        }
    }
}
