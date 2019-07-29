using PYPA.Bankrupt.Core;
using System;
using System.Collections.Generic;

namespace PYPA.Bankrupt
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            pairs.Add(0,0);
            pairs.Add(1, 0);
            pairs.Add(2,0);
            pairs.Add(3, 0);
            pairs.Add(4, 0);
            pairs.Add(5, 0);
            Roller r = new Roller();
            int i = 0;

            while (i++ < 1000000) {
                var rdm = r.RollInt(6);
                pairs[rdm]++;
            }
            Console.WriteLine($"{pairs[0]}  {pairs[1]} {pairs[2]} {pairs[3]} {pairs[4]} {pairs[5]}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            //Console.WriteLine($"{r.RollInt(6)}  {r.RollRNGInt(6)}");
            Console.WriteLine("Hello World!");
        }
    }
}
