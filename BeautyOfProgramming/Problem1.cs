using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeautyOfProgramming
{
    /*
     * 让CPU占有率曲线听你指挥
     */
    public class Problem1
    {
        public void Approach1()
        {
            for (; ; )
            {
                for (int i = 0; i < 9600000; i++)
                    ;
                Thread.Sleep(10);
            }
        }

        public void Approach2()
        {
            const int busyTime = 10;
            const int idleTime = busyTime;

            Int64 startTime = 0;
            while (true)
            {
                startTime = Environment.TickCount;
                while ((Environment.TickCount - startTime) <= busyTime) ;

                Thread.Sleep(idleTime);
            }
        }

        public void Approach3(float level)
        {
            PerformanceCounter p = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            while (true)
            {
                if (p.NextValue() > level)
                    System.Threading.Thread.Sleep(10);
            }
        }

        public void Approach4()
        {
            const int SAMPLING_COUNT = 200;
            const double PI = 3.1415926535;
            const int TOTAL_AMPLITUDE = 300;

            var busySpan = new int[SAMPLING_COUNT];
            int amplitude = TOTAL_AMPLITUDE / 2;
            double radian = 0.0;
            double radianIncrement = 2.0 / (double)SAMPLING_COUNT;
            for (int i = 0; i < SAMPLING_COUNT; i++)
            {
                busySpan[i] = (int)(amplitude + Math.Sin(PI * radian) * amplitude);
                radian += radianIncrement;
            }

            int startTime = 0;
            for (int j = 0; ; j = (j + 1) % SAMPLING_COUNT)
            {
                startTime = Environment.TickCount;
                while ((Environment.TickCount - startTime) <= busySpan[j]) ;
                Thread.Sleep(TOTAL_AMPLITUDE - busySpan[j]);
            }
        }
    }
}
