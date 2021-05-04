using LoopPerformanceLib.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace LoopPerformanceLib
{
    public static class Helpers
    {
        /// <summary>
        /// Create sample randomly, not depend on the index
        /// </summary>
        /// <param name="numberOfItems"></param>
        /// <returns></returns>
        private static List<Foo> CreateSamplesRandom(int numberOfItems)
        {
            Random r = new Random();
            List<Foo> list = new List<Foo>();

            for (int i = 0; i < numberOfItems; i++)
            {
                list.Add(new Foo
                {
                    Name = $"Name{r.Next(numberOfItems)}",
                    Age = r.Next(numberOfItems)
                });
            }
            return list;
        }

        /// <summary>
        /// Create samples depend on index value
        /// </summary>
        /// <param name="numberOfItems"></param>
        /// <returns></returns>
        private static List<Foo> CreateSamplesInOrder(int numberOfItems)
        {
            Random r = new Random();
            List<Foo> list = new List<Foo>();

            for (int i = 0; i < numberOfItems; i++)
            {
                list.Add(new Foo
                {
                    Name = $"Name{i}", //Name1
                    Age = i
                });
            }
            return list;
        }

        private static void SearchingTaskFirstItem(ICollection<Foo> foos, ICollection<Foo> required)
        {
            Stopwatch stopwatch = new Stopwatch();

            foreach (var item in required)
            {
                stopwatch.Restart();
                var first = foos.FirstOrDefault(f => f.Name == item.Name);
                stopwatch.Stop();
                Console.WriteLine($"{(int)(stopwatch.ElapsedTicks / (double)Stopwatch.Frequency * 1000000)}");
            }
        }

        private static void SearchingTaskContainItem(ICollection<Foo> foos, ICollection<Foo> required)
        {
            Stopwatch stopwatch = new Stopwatch();

            foreach (var item in required)
            {
                stopwatch.Restart();
                var isExist = foos.Contains(item);
                stopwatch.Stop();
                Console.WriteLine($"{isExist}-{(int)(stopwatch.ElapsedTicks / (double)Stopwatch.Frequency * 1000000)} ns");
            }
        }

        private static void SearchingTaskString(ICollection<Foo> foos, ICollection<Foo> required)
        {
            Stopwatch stopwatch = new Stopwatch();

            var sampleString = string.Join("\n", foos.Select(f => Deserialize(f)));

            foreach (var item in required)
            {
                stopwatch.Restart();

                var matchString = Regex.Match(sampleString, $"^{item.Name}");

                stopwatch.Stop();
                Console.WriteLine($"{matchString} - {(int)(stopwatch.ElapsedTicks / (double)Stopwatch.Frequency * 1000000)} ns");
            }
        }

        public static void SampleRun(int sampleCount)
        {
            Console.WriteLine("Searching 2000 items in list of samples");
            Console.WriteLine($"************{sampleCount} samples*************");

            var samples = CreateSamplesInOrder(sampleCount);
            var searchingItems = CreateSamplesInOrder(2000);

            SearchingTaskFirstItem(samples, searchingItems);
        }

        public static void SampleRun1(int sampleCount)
        {
            var samples = CreateSamplesInOrder(30000);
            var searchingItems = CreateSamplesInOrder(2000);

            SearchingTaskContainItem(samples, searchingItems);
        }
        public static void SampleRun2(int sampleCount)
        {
            var samples = CreateSamplesInOrder(sampleCount);
            var searchingItems = CreateSamplesInOrder(2000);

            SearchingTaskString(samples, searchingItems);
        }

        private static string Deserialize(Foo foo)
        {
            return $"{foo.Name}-{foo.Age}";
        }


    }
}
