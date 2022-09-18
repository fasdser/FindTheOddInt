using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheOddInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
            Console.ReadLine();
        }

        public static int find_it(int[] seq)
        {
            if (seq.Length == 1)
            {
                return seq.First();
            }
            var list = new List<int>();
            list.AddRange(seq);


            var a = list.Distinct().ToArray();
            var dictionary = new Dictionary<int, int>();
            int n = 0;

            foreach (var value in a)
            {
                foreach (var item in seq)
                {
                    if (value == item)
                    {
                        n++;
                    }
                }
                dictionary[value] = n;
                n = 0;
            }
            var b= dictionary.ToList().Where(x => x.Value % 2 == 1).Min().Key;
           // foreach (var item in b)
                Console.WriteLine(b);

            return b;
        }

        public static int find_it1(int[] seq)
        {
            return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
        }

        public static int find_it2(int[] seq)
        {
            int found = 0;

            foreach (var num in seq)
            {
                found ^= num;
            }

            return found;
        }

        public static int find_it3(int[] seq)
        {
            return seq.First(x => seq.Count(s => s == x) % 2 == 1);
        }
    }
}
